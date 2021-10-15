# Hello world
```
from pyspark.sql import SparkSession
spark: SparkSession = SparkSession.builder.appName("SimpleApp").getOrCreate()
# do something to prove it works
spark.sql('SELECT "Test" as c1').show()
```

### Reference
- PySpark - .NET 開発基盤部会 Wiki > 詳細 > チュートリアル > on Jupyter Notebook on Docker  
https://dotnetdevelopmentinfrastructure.osscons.jp/index.php?PySpark#ffe40eef
