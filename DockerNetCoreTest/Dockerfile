#FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
#WORKDIR /app
#EXPOSE 49942
#EXPOSE 44357
#
#FROM microsoft/dotnet:2.1-sdk AS build
#WORKDIR /src
#COPY ["DockerNetCoreTest/DockerNetCoreTest.csproj", "DockerNetCoreTest/"]
#RUN dotnet restore "DockerNetCoreTest/DockerNetCoreTest.csproj"
#COPY . .
#WORKDIR "/src/DockerNetCoreTest"
#RUN dotnet build "DockerNetCoreTest.csproj" -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish "DockerNetCoreTest.csproj" -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "DockerNetCoreTest.dll"]



## 添加基础镜像
#FROM microsoft/dotnet:2.1-aspnetcore-runtime
##容器中系统的工作空间
#WORKDIR /app
##拷贝当前文件夹下的文件到容器中系统的工作空间
#COPY . /app
 #
##设置Docker容器对外暴露的端口
#EXPOSE 80
##容器中使用 ["dotnet","系统启动的dll"] 来运行应用程序
##使用ENTRYPOINT ["dotnet","系统启动的dll"]
##或使用 CMD ["dotnet","系统启动的dll"]
#ENTRYPOINT ["dotnet", "DockerNetCoreTest.dll"]




FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY DockerNetCoreTest/*.csproj ./DockerNetCoreTest/
RUN dotnet restore

# copy everything else and build app
COPY DockerNetCoreTest/. ./DockerNetCoreTest/
WORKDIR /app/DockerNetCoreTest
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/DockerNetCoreTest/out ./
ENTRYPOINT ["dotnet", "DockerNetCoreTest.dll"]