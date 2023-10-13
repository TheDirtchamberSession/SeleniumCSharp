# Use the official Microsoft .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

# Handle broken or unconfigured packages
RUN dpkg --configure -a
RUN apt-get clean
RUN apt-get update -qq

# Install required utilities
RUN apt-get install -y wget gnupg software-properties-common xvfb x11vnc ffmpeg psmisc procps

# Install Chrome and required utilities
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list \
    && apt-get update -qq \
    && apt-get install -y google-chrome-stable

# Install ChromeDriver
RUN CHROME_DRIVER_VERSION=$(curl -sS chromedriver.storage.googleapis.com/LATEST_RELEASE) && \
    wget "https://edgedl.me.gvt1.com/edgedl/chrome/chrome-for-testing/118.0.5993.70/linux64/chromedriver-linux64.zip" -P ~/ && \
    unzip ~/chromedriver-linux64.zip -d ~/ && \
    mv ~/chromedriver-linux64/chromedriver /usr/local/bin/chromedriver && \
    chmod +x /usr/local/bin/chromedriver

# Set display port to avoid crash of GUI-based browser
ENV DISPLAY=:99

# Set working directory
WORKDIR /app

# Copy the test project files into the container at /app
COPY ./SeleniumProjectTest/*.csproj ./
RUN dotnet restore

COPY ./SeleniumProjectTest/ ./

# Restore packages for the test project and build the project
RUN dotnet publish -c Release -o out

# Define entrypoint to run your tests
ENTRYPOINT ["dotnet", "out/SeleniumProjectTest.dll"]

# Copy run-tests.sh if you have one
COPY run-tests.sh /app/



