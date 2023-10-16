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

3. Live Preview on:
http://localhost:4444/grid/admin/live
Zelenium Dashboard on:
http://localhost:4444/dashboard/#

See the - BaseTestHub class In the project for a greater understanding of how everything is set up.

Note:
Added video test recording and taking a picture of each failed test in the project.

Use the docker file to build the project and then run inside container tests using commands like:
dotnet test
or
dotnet vstest SeleniumProjectTest.dll

Note: All Package Reference is in the file - SeleniumProjectTest.csproj

