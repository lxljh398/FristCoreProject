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



# ���ӻ�������
FROM microsoft/dotnet:2.1-aspnetcore-runtime
#������ϵͳ�Ĺ����ռ�
WORKDIR /app
#������ǰ�ļ����µ��ļ���������ϵͳ�Ĺ����ռ�
COPY . /app
 
#����Docker�������Ⱪ¶�Ķ˿�
EXPOSE 80
#������ʹ�� ["dotnet","ϵͳ������dll"] ������Ӧ�ó���
#ʹ��ENTRYPOINT ["dotnet","ϵͳ������dll"]
#��ʹ�� CMD ["dotnet","ϵͳ������dll"]
ENTRYPOINT ["dotnet", "DockerNetCoreTest.dll"]