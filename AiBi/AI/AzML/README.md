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
mlCompInstanceName=myazmlinstance
mlCompClusterName=myazmlcluster
mlCompVmSize=Standard_D2s_v3
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

az ml workspace create --workspace-name $mlWorkSpaceName --resource-group $dataPipelineRgName --location $location
```

Create a computing environment.

Instance
```Bash
az ml computetarget create computeinstance \
  --name $mlCompInstanceName \
  --workspace-name $mlWorkSpaceName \
  --resource-group $dataPipelineRgName \
  --vm-size $mlCompVmSize
```

Cluster
```Bash
az ml computetarget create amlcompute \
  --name $mlCompClusterName \
  --workspace-name $mlWorkSpaceName \
  --resource-group $dataPipelineRgName \
  --assign-identity '[system]' \
  --vm-size $mlCompVmSize \
  --min-nodes 0 \
  --max-nodes 2 \
  --idle-seconds-before-scaledown 120
```

### Reference
- Azure Machine Learningチュートリアル - マイクロソフト系技術情報 Wiki  
https://techinfoofmicrosofttech.osscons.jp/index.php?Azure%20Machine%20Learning%E3%83%81%E3%83%A5%E3%83%BC%E3%83%88%E3%83%AA%E3%82%A2%E3%83%AB