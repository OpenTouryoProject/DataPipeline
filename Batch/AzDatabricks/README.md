# AzDatabricks

## Sample
See the [Spark sample](../Spark).

## IaC
This IaC is building Azure Databricks as distributed computing platform.

### Variables

#### Define
```PowerShell
$location="westus2"
$dataPipelineRgName="DplRG"
$managedRgName="DatabricksRG"
$databricksName="mydatabricksws"
$sku="standard"
```

#### Check
```PowerShell
echo $location
echo $dataPipelineRgName
echo $managedRgName
echo $databricksName
echo $sku
```

### Create Workspace
If the ResourcesGroup does not exist, create it.
```PowerShell
New-AzResourceGroup -Name $dataPipelineRgName -Location $location
```

Create a Databricks workspace.
```PowerShell
Connect-AzAccount
Register-AzResourceProvider -ProviderNamespace Microsoft.Databricks
New-AzDatabricksWorkspace -Name $databricksName -ResourceGroupName $dataPipelineRgName -Location $location -ManagedResourceGroupName $managedRgName -Sku $sku
```
