# Simplest

### Variables

#### Define
```Bash
location=westus2
dataPipelineRgName=DplRG
eventhubsNameSpace=osscjpdevinfra
eventhubsName=OsscJpDevInfra
```

#### Check
```Bash
echo $location
echo $dataPipelineRgName
echo $eventhubsNameSpace
echo $eventhubsName
```

### Creating an EventHubs
```Bash
az group create --name $dataPipelineRgName --location $location

az eventhubs namespace create \
  --name $eventhubsNameSpace \
  --resource-group $dataPipelineRgName \
  --location $location

az eventhubs eventhub create \
  --name $eventhubsName \
  --resource-group $dataPipelineRgName \
  --namespace-name $eventhubsNameSpace

```

Add as needed.
```Bash
az eventhubs namespace network-rule add \
  --ip-address xxx.xxx.xxx.xxx \
  --resource-group $dataPipelineRgName \
  --namespace-name $eventhubsNameSpace
  
az eventhubs namespace network-rule list \
  --resource-group $dataPipelineRgName \
  --namespace-name $eventhubsNameSpace
```

### Reference
- Azure Event Hubsチュートリアル - マイクロソフト系技術情報 Wiki
https://techinfoofmicrosofttech.osscons.jp/index.php?Azure%20Event%20Hubs%E3%83%81%E3%83%A5%E3%83%BC%E3%83%88%E3%83%AA%E3%82%A2%E3%83%AB
