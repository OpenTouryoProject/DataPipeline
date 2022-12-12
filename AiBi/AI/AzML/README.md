# AzML
Azure Machine Learning

## Sample

## IaC
This IaC is building Azure Machine Learning as trusted platform designed for responsible machine learning (ML).

### Variables

#### Define
```Bash
location=westus2
dataPipelineRgName=DplRG
mlWorkSpaceName=myazmlws
mlCompInstanceName=myazmlinstance
mlCompClusterName=myazmlcluster
mlCompVmSize=Standard_DS3_v2 or Standard_NC6
```

#### Check
```Bash
echo $location
echo $dataPipelineRgName
echo $mlWorkSpaceName
echo $mlCompInstanceName
echo $mlCompClusterName
echo $mlCompVmSize
```

### Creating an AzML

Execute only the first time.
```Bash
az extension add -n azure-cli-ml
```

Create a workspace.

```Bash
az group create --name $dataPipelineRgName --location $location

az ml workspace create --name $mlWorkSpaceName --resource-group $dataPipelineRgName --location $location
```

Create a computing environment.

Instance
```Bash
az ml compute create \
  --type ComputeInstance \
  --name $mlCompInstanceName \
  --workspace-name $mlWorkSpaceName \
  --resource-group $dataPipelineRgName \
  --size $mlCompVmSize
```

Cluster
```Bash
az ml compute create \
  --type AmlCompute \
  --name $mlCompClusterName \
  --workspace-name $mlWorkSpaceName \
  --resource-group $dataPipelineRgName \
  --size $mlCompVmSize \
  --min-instances 0 \
  --max-instances 2 \
  --idle-time-before-scale-down 120
```

### Reference
- Azure Machine Learningチュートリアル - マイクロソフト系技術情報 Wiki  
https://techinfoofmicrosofttech.osscons.jp/index.php?Azure%20Machine%20Learning%E3%83%81%E3%83%A5%E3%83%BC%E3%83%88%E3%83%AA%E3%82%A2%E3%83%AB
