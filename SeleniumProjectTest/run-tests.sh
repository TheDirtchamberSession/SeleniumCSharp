#!/bin/bash

# Start Xvfb
Xvfb :99 -ac &
export DISPLAY=:99

# Start recording with ffmpeg (recording will start in the background)
ffmpeg -video_size 1366x768 -framerate 25 -f x11grab -i :99.0 output.mp4 &

# Optionally, start VNC server if you want to watch in real-time
# x11vnc -forever -usepw -create -display :99 &

# Run your tests
dotnet test

# Kill the ffmpeg process after tests are done
killall ffmpeg