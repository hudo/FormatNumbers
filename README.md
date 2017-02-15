# Human Numbers

Human readable numbers formatter.

## Work in progress!  

### Examples

*Time:*  
Input: TimeSpan  
Output:  
just now  
20 seconds ago  
10 minutes ago  
2 days ago


*Size:*  
Input: bytes  
Output:  
42 KB  
5 MB  
10 GB    


## Usage  

```cs
  
var ago = TimeFormat.Ago(timeSpan);  
var size = SizeFormat.Readable(sizeInBytes);  
  
  
// or    
  
using static HumanNumbers.TimeFormat  
using static HumanNumbers.SizeFormat  

var ago = Ago(timeSpan);  
var size Readable(sizeInBytes);  

```