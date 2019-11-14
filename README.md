# swagger.net-apikey-practice
swagger.net auth token apikey

this is an asp.net webapi project. the api use token for auth. the project show how to auth with swagger.

# usage step
1. install swagger.net from nuget
2. create **MyAuthorizeAttribute.cs** in App_Start folder
3. create **TokenFilter.cs** in App_Start folder
4. create **OrderController.cs** in Controllers folder
5. in [SwaggerConfig.cs](https://github.com/github-amazingboy/swagger.net-apikey-practice/blob/master/swaggernet-apikey/App_Start/SwaggerConfig.cs#L74-L75)  do some changes.
   ```C#
   c.ApiKey("apiKey", "header", "API Key Authentication");
   c.OperationFilter<TokenFilter>();
   ```

# the running result
![auth](https://rawcdn.githack.com/github-amazingboy/swagger.net-apikey-practice/4fcfda4871c379c12e7a008a9018ef723033c374/auth1.png)

![auth](https://rawcdn.githack.com/github-amazingboy/swagger.net-apikey-practice/4fcfda4871c379c12e7a008a9018ef723033c374/auth2.png?raw=true)

