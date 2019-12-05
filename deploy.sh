dotnet publish -r linux-arm
rsync -avh bin/Debug/netcoreapp3.0/linux-arm/publish /Volumes/share
