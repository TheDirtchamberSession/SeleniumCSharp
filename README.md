# SeleniumCSharp - Grid

Just a small test project to see how to use the Selenium web driver with c#.
Selenium Grid allows you to run your tests on different machines against different browsers. 

For video recording of Selenium tests when they're running inside Docker containers I use a solution like Zalenium.
Zalenium provides Docker containers that can run Selenium Grid nodes with video recording capabilities.

Steps:
1. First do a pull for zelenium and elgalu/selenium

docker pull dosel/zalenium

docker pull elgalu/selenium

2.
Run Zelenium
docker run --rm -ti --name zalenium -p 4444:4444 -v /var/run/docker.sock:/var/run/docker.sock -v /tmp/videos:/home/seluser/videos --privileged dosel/zalenium start

The part -v /tmp/videos:/home/seluser/videos maps the /tmp/videos directory on your host machine to the /home/seluser/videos directory inside the Zalenium container.
So, after the test is completed:
Locate the Video on Your Machine:
You should be able to find the video files in the /tmp/videos directory on your machine.

4. Live Preview on:
http://localhost:4444/grid/admin/live

![image](https://github.com/TheDirtchamberSession/SeleniumCSharp/assets/33664649/e98842f6-46cf-4159-8a97-f6d7c3398038)

Zelenium Dashboard on:
http://localhost:4444/dashboard/#

![image](https://github.com/TheDirtchamberSession/SeleniumCSharp/assets/33664649/3fd63db4-5ff2-429e-8235-630badc7f022)


See the - BaseTestHub class In the project for a greater understanding of how everything is set up.

Note:
Added video test recording and taking a picture of each failed test in the project.

Use the docker file to build the project and then run inside container tests using commands like:
dotnet test
or
dotnet vstest SeleniumProjectTest.dll

Note: All Package Reference is in the file - SeleniumProjectTest.csproj
