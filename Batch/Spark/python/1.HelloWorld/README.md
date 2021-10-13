# Hello world
```
from pyspark.sql import SparkSession
spark: SparkSession = SparkSession.builder.appName("SimpleApp").getOrCreate()
# do something to prove it works
spark.sql('SELECT "Test" as c1').show()
```
