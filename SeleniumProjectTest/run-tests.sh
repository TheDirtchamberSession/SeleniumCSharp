#!/bin/bash

# Set the resolution for Xvfb and ffmpeg
RESOLUTION="1280x1024"

# Check and kill existing Xvfb process on display :99
existing_pid=$(pgrep -f "Xvfb :99")
if [[ ! -z "$existing_pid" ]]; then
  echo "Killing existing Xvfb process on display :99..."
  kill "$existing_pid"
  sleep 2
fi

# Start Xvfb with the specified resolution
echo "Starting Xvfb on display :99 with resolution $RESOLUTION..."
Xvfb :99 -screen 0 ${RESOLUTION}x24 -ac &
sleep 2

# Verify that Xvfb is running
if ! pgrep -f "Xvfb :99"; then
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

# Start recording with ffmpeg using the same resolution
echo "Starting ffmpeg recording..."
DISPLAY=:99 ffmpeg -video_size $RESOLUTION -framerate 25 -f x11grab -i :99.0 /app/output.mp4 > /app/ffmpeg.log 2>&1 &

# Allow ffmpeg to initialize
sleep 10

# Execute your tests
echo "Running dotnet tests..."
dotnet test

# Kill the ffmpeg process after tests are done
pkill -f "ffmpeg.*x11grab.*:99.0" || echo "ffmpeg was not running."

# Print the ffmpeg log for diagnostics
cat /app/ffmpeg.log