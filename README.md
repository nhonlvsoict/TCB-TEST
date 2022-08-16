# TCB-TEST
 .NET Core API app deployed in Microsoft Azure 
## Endpoint: https://tcb-test20220810194857.azurewebsites.net
## API Definition: 
- POST /api/appendorinsert
        
        curl --location --request POST 'https://tcb-test20220810194857.azurewebsites.net/api/appendorinsert' \
        --header 'Content-Type: application/json' \
        --header 'Cookie: ARRAffinity=dc7a138dfcb63bce17254cc4321cf14c9178fc6ae4c339b927686049d314ddf6; ARRAffinitySameSite=dc7a138dfcb63bce17254cc4321cf14c9178fc6ae4c339b927686049d314ddf6' \
        --data-raw '{
        "poolId": 1293,
        "poolValues": [
        1,
        7.99
        ]
        }'
- POST /api/appendorinsert
        curl --location --request POST 'https://tcb-test20220810194857.azurewebsites.net/api/querypercentile' \
        --header 'Content-Type: application/json' \
        --header 'Cookie: ARRAffinity=dc7a138dfcb63bce17254cc4321cf14c9178fc6ae4c339b927686049d314ddf6; ARRAffinitySameSite=dc7a138dfcb63bce17254cc4321cf14c9178fc6ae4c339b927686049d314ddf6' \
        --data-raw '{
        "poolId": 1293,
        "percentile":49.5
        }'
        
## Folder architechture:
![image](https://user-images.githubusercontent.com/44114705/184449630-bec5937d-df5c-4a18-885d-d4880884e73e.png)
## Testing:
- Unit test: Mock PoolRepository to test for PoolService
- Test case: Wrong input json type, wrong input format, input overflow,..

## CI-CD with Azure:
![image](https://user-images.githubusercontent.com/44114705/184450933-7ee76bf3-195e-4423-b2b1-40ea1a974a0a.png)
- Visual Studio: editor, application source code
- GitHub: remote source 
- Azure Test Plans: Continuous integration triggers application build and unit tests
- Azure Pipelines: Continuous deployment triggers an automated deployment of application artifacts 
- Azure App Service: deploy artifact to web app


## High performance & Resiliency

- Caching: Client side request caching, server side data caching in Repository
- Asynchronous approach: allow our API to work more efficiently with the ASP.NET Core thread pool

## High Availability & Scalability
- Azure App Service: Monolithic approach: Host running multiple apps, each app running as a container using Docker. This approch facilitate scalability and HA by Azure balancer.
- Azure Application Insights: collects and analyzes health, performance, and usage data.

![image](https://user-images.githubusercontent.com/44114705/184447494-15a386b5-b46c-410f-a372-5b79d2783445.png)
