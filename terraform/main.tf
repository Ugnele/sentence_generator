terraform {
    required_providers {
        azurerm = {
            source  = "hashicorp/azurerm"
            version = "~> 2.46.0"
        }
    }
}

provider "azurerm" {
    features {}
}

locals {
    
}

resource "azurerm_resource_group" "main" {
    name     = var.rg_name
    location = var.location

    tags     = {
      project = "true"
    }
}

resource "azurerm_app_service_plan" "main" {
  name                = "${var.my_name}-project-appservice"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
  #kind                = "Linux"
  #reserved            = true

  sku {
    tier = "Free"
    size="F1"
  }

  tags = {
    project = "true"
  }
}

resource "azurerm_app_service" "service12" {
  count               = 2 # create 4 similar app services
  name                = "${var.my_name}-webapp${count.index + 1}"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
  app_service_plan_id = azurerm_app_service_plan.main.id

  site_config {
    dotnet_framework_version = "v5.0"
    scm_type                 = "LocalGit"
    use_32_bit_worker_process = true
  }
  
  app_settings = {
    "WEBSITE_WEBDEPLOY_USE_SCM" = "true"
  }

  tags = {
    project = "true"
  }
}

resource "azurerm_app_service" "service3" {
  name                = "${var.my_name}-webapp3"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
  app_service_plan_id = azurerm_app_service_plan.main.id

  site_config {
    dotnet_framework_version = "v5.0"
    scm_type                 = "LocalGit"
    use_32_bit_worker_process = true
  }

  app_settings = {
    "StorageAccountName"      = "ugnestorageaccount"
    StorageConnectionString   = var.StorageConnectionString
    StorageAccountKey         = var.StorageAccountKey
    "WEBSITE_WEBDEPLOY_USE_SCM" = "true"
  }
  
  tags = {
    project = "true"
  }
}

resource "azurerm_app_service" "service4" {
  name                = "${var.my_name}-webapp4"
  location            = azurerm_resource_group.main.location
  resource_group_name = azurerm_resource_group.main.name
  app_service_plan_id = azurerm_app_service_plan.main.id

  site_config {
    dotnet_framework_version = "v5.0"
    scm_type                 = "LocalGit"
    use_32_bit_worker_process = true
  }

  app_settings = {
    "lengthServiceURL" = "https://ugne-webapp2.azurewebsites.net/length"
    "wordsServiceURL"  = "https://ugne-webapp3.azurewebsites.net/words"
    "WEBSITE_WEBDEPLOY_USE_SCM" = "true"
  }
  
  tags = {
    project = "true"
  }
}

resource "azurerm_storage_account" "main" {
  name                     = "${var.my_name}storageaccount"
  resource_group_name      = azurerm_resource_group.main.name
  location                 = azurerm_resource_group.main.location
  account_tier             = "Standard"
  account_replication_type = "LRS"

  tags = {
    project = "true"
  }
}

resource "azurerm_storage_container" "main" {
  name                  = "project"
  storage_account_name  = azurerm_storage_account.main.name
  container_access_type = "blob"
}

resource "azurerm_storage_blob" "example" {
  for_each               = var.resources
  name                   = "${each.key}.txt"
  storage_account_name   = azurerm_storage_account.main.name
  storage_container_name = azurerm_storage_container.main.name
  type                   = "Block"
}