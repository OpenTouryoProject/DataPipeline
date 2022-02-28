# AzML
Azure Machine Learning

### Sample

### IaC
This IaC is building Azure Machine Learning as trusted platform designed for responsible machine learning (ML).

### Variables

#### Define
```Bash
location=westus2
dataPipelineRgName=DplRG
mlWorkSpaceName=myazmlws
```

#### Check
```Bash
echo $location
echo $dataPipelineRgName
echo $mlWorkSpaceName
```

### Creating an EventHubs
```Bash
az group create --name $dataPipelineRgName --location $location

az ml workspace create --workspace-name $mlWorkSpaceName --resource-group $dataPipelineRgName --location $location
```


### Reference
- Azure Machine Learningチュートリアル - マイクロソフト系技術情報 Wiki  
https://techinfoofmicrosofttech.osscons.jp/index.php?Azure%20Machine%20Learning%E3%83%81%E3%83%A5%E3%83%BC%E3%83%88%E3%83%AA%E3%82%A2%E3%83%AB

