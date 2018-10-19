# LogUtil
Log Example in C#

Can configure route and name of log in app.config
```
  <Rutes>
    <add key="Log" value="D:\\" />
  </Rutes>
  <Names>
    <add key="Log" value="Log.log" />
  </Names>
```
Result Example:
```
Init 19/10/2018 18:53:28
	Example Text
	Error in Creating Error: 	Referencia a objeto no establecida como instancia de un objeto.
	Total: 00:00:00.1599075
End 19/10/2018 18:53:28
```

if you do not want the total time
```
LogUtilClass log = new LogUtilClass(false);
```
the result see like
```
Init 19/10/2018 18:53:28
	Example Text
	Error in Creating Error: 	Referencia a objeto no establecida como instancia de un objeto.
End 19/10/2018 18:53:28
```
