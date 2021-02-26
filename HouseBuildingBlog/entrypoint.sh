#!/bin/bash

set -e
run_cmd="dotnet run --project ./HouseBuildingBlog/HouseBuildingBlog.Api.csproj --launch-profile Docker  --urls http://*:5000;https://*:5001"

>&2 echo "SQL Server is up - executing command"
exec $run_cmd