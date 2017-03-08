# Deployment

Using Docker Compose to deploy the containers to Azure Container Service (ACS)

1. Make sure your latest images are in Docker Hub, whether manually or via CI. They are deployed to ACS from here. (i.e. `docker-compose push` after they are built)

1. Log into the master ACS VM. There is a SSH key provided in this directory to do so:

`ssh -i .ssh/id_rsa excellaacs@excellaacsmgmt.eastus.cloudapp.azure.com -A -p 2200`

1. Deploy the containers:

`docker-compose -f .\docker-compose.prod.yml push`

