#!/bin/bash

# Set the resolution for Xvfb and ffmpeg
RESOLUTION="1280x1024"

# Check and kill existing Xvfb process
if ps aux | grep "Xvfb :99" | grep -v grep; then
  echo "Killing existing Xvfb process..."
  killall Xvfb
  sleep 2
fi

# Cleanup any lingering Xvfb related files
rm -f /tmp/.X99-lock

# Start Xvfb with the specified resolution
echo "Starting Xvfb on display :99 with resolution $RESOLUTION..."
Xvfb :99 -screen 0 ${RESOLUTION}x24 -ac &
sleep 2

# Verify that Xvfb is running
echo "Checking Xvfb status:"
if ! ps aux | grep "Xvfb :99" | grep -v grep; then
  echo "Error: Xvfb is not running."
  exit 1
fi

# Check the availability of the display
if ! xdpyinfo -display :99 > /dev/null 2>&1; then
  echo "Error: Display :99 is not available."
  exit 1
fi

# Give some time for Xvfb to fully initialize
sleep 10

# Set DISPLAY variable
export DISPLAY=:99

# Start recording with ffmpeg with an explicit resolution
echo "Starting ffmpeg recording..."
ffmpeg -video_size 1280x1024 -framerate 25 -f x11grab -i :99.0 /app/output.mp4 > /app/ffmpeg.log 2>&1 &

# Allow ffmpeg to initialize
sleep 10

# Execute your tests
echo "Running dotnet tests..."
dotnet test

# Kill the ffmpeg process after tests are done
killall ffmpeg || echo "ffmpeg was not running."

# Print the ffmpeg log for diagnostics
cat /app/ffmpeg.log