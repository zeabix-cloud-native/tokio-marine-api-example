# .NET Tokio marine api example

This is a minimal API project built with .NET 8 (or later) that uses Swagger for API documentation. This project includes an endpoint for updating TODO items and demonstrates how to configure Swagger to display example requests.

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or any other IDE of your choice that supports .NET 8

## Installation

1. **Clone the repository**

   ```sh
   git clonehttps://github.com/zeabix-cloud-native/tokio-marine-api-example.git
   cd /tokio-marine-api-example

   ```

2. Install dependencies

   ```sh
   dotnet restore
   dotnet build
   ```

3. Run application

   ```sh
   dotnet run
   
## Command to generate openapi.json
   ```sh
   curl http://localhost:5259/swagger/v1/swagger.json -o docs/openapi.json
   ```

## Access swagger
   ```sh
   <app-url>/swagger/index.html
   ```

## Environment 
<span style="color: red;">On-premises server for external REST API Mockups</span>

<table>
<tr>
   <td>Authentication Type</td>
   <td>API Key</td>
</tr>
</table>

<table>
<tr>
<td> Environment </td> 
<td> API type </td>
<td> HTTP Response Body </td>
</tr>
<tr>
<td> Development </td>
<td> REST </td>
<td>

```
"metadata": {
   "Exposure": "External",
   "API TYPE": "REST",
   "Authen Method": "API KEY",
   "Environment": "Development",
   "Infrastructure": "On-premises"
}
```
</td>
</tr>
<tr>

<tr>
<td> UAT </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "External",
  "API TYPE": "REST",
  "Authen Method": "API KEY",
  "Environment": "UAT",
  "Infrastructure": "On-premises"
}
```

</td>
</tr>

<tr>
<td> Production </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "External",
  "API TYPE": "REST",
  "Authen Method": "API KEY",
  "Environment": "UAT",
  "Infrastructure": "On-premises"
}
```

</td>
</tr>
</table>

<span style="color: red;">On-premises server for external REST API Mockups</span>
<table>
<tr>
   <td>Authentication Type</td>
   <td>Oauth2.0</td>
</tr>
</table>

<table>
<tr>
<td> Environment </td> 
<td> API type </td>
<td> HTTP Response Body </td>
</tr>
<tr>
<td> Development </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "External",
  "API TYPE": "REST",
  "Authen Method": "Oauth2.0",
  "Environment": "Development",
  "Infrastructure": "On-premises"
}
```
</td>
</tr>
<tr>

<tr>
<td> UAT </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "External",
  "API TYPE": "REST",
  "Authen Method": "Oauth2.0",
  "Environment": "UAT",
  "Infrastructure": "On-premises"
}
```

</td>
</tr>

<tr>
<td> Production </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "External",
  "API TYPE": "REST",
  "Authen Method": "Oauth2.0",
  "Environment": "Production",
  "Infrastructure": "On-premises"
}
```

</td>
</tr>
</table>

<span style="color: blue;">On-premises server for external REST API Mockups</span>
<table>
<tr>
   <td>Authentication Type</td>
   <td>Oauth2.0</td>
</tr>
</table>

<table>
<tr>
<td> Environment </td> 
<td> API type </td>
<td> HTTP Response Body </td>
</tr>
<tr>
<td> Development </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "Internal",
  "API TYPE": "REST",
  "Authen Method": "API KEY",
  "Environment": "Development",
  "Infrastructure": "On-premises"
}
```
</td>
</tr>
<tr>

<tr>
<td> UAT </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "Internal",
  "API TYPE": "REST",
  "Authen Method": "API KEY",
  "Environment": "UAT",
  "Infrastructure": "On-premises"
}
```

</td>
</tr>

<tr>
<td> Production </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "Internal",
  "API TYPE": "REST",
  "Authen Method": "API KEY",
  "Environment": "Production",
  "Infrastructure": "On-premises"
}
```

</td>
</tr>
</table>

<span style="color: blue;">On-premises server for external REST API Mockups</span>
<table>
<tr>
   <td>Authentication Type</td>
   <td>Oauth2.0</td>
</tr>
</table>

<table>
<tr>
<td> Environment </td> 
<td> API type </td>
<td> HTTP Response Body </td>
</tr>
<tr>
<td> Development </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "Internal",
  "API TYPE": "REST",
  "Authen Method": "Oauth2.0",
  "Environment": "Development",
  "Infrastructure": "On-premises"
}
```
</td>
</tr>
<tr>

<tr>
<td> UAT </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "Internal",
  "API TYPE": "REST",
  "Authen Method": "Oauth2.0",
  "Environment": "UAT",
  "Infrastructure": "On-premises"
}
```

</td>
</tr>

<tr>
<td> Production </td>
<td> REST </td>
<td>

```
"metadata": {
  "Exposure": "Internal",
  "API TYPE": "REST",
  "Authen Method": "Oauth2.0",
  "Environment": "Production",
  "Infrastructure": "On-premises"
}
```

</td>
</tr>
</table>