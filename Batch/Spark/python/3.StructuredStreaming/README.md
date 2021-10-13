# Structured streaming
```
import sys

from pyspark.sql import SparkSession
from pyspark.sql.functions import explode
from pyspark.sql.functions import split
from pyspark.sql.functions import window

host = "xxx.xxx.xxx.xxx"
port = 9999
windowSize = 10
slideSize  = 10
if slideSize > windowSize:
    print("<slideSize> must be less than or equal to <windowSize>", file=sys.stderr)
windowDuration = '{} seconds'.format(windowSize)
slideDuration = '{} seconds'.format(slideSize)

spark = SparkSession\
    .builder\
    .appName("StructuredNetworkWordCountWindowed")\
    .getOrCreate()

# Create DataFrame representing the stream of input lines from connection to host:port
lines = spark\
    .readStream\
    .format('socket')\
    .option('host', host)\
    .option('port', port)\
    .option('includeTimestamp', 'true')\
    .load()

# Split the lines into words, retaining timestamps
# split() splits each line into an array, and explode() turns the array into multiple rows
words = lines.select(
    explode(split(lines.value, ' ')).alias('word'),
    lines.timestamp
)

# Group the data by window and word and compute the count of each group
windowedCounts = words.groupBy(
    window(words.timestamp, windowDuration, slideDuration),
    words.word
).count().orderBy('window')

# Start running the query that prints the windowed word counts to the console
query = windowedCounts\
    .writeStream\
    .outputMode('complete')\
    .format('console')\
    .option('truncate', 'false')\
    .start()

query.awaitTermination()
```

https://dotnetdevelopmentinfrastructure.osscons.jp/index.php?PySpark#x623bccd