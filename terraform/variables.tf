variable "my_name" {
  default = "ugne"
}

variable "location" {
  default = "uksouth"
}

variable "rg_name" {
  default = "ugnesarakauskaite"
}

variable "appservice" {
  default = {
    location            = "uksouth"
    resource_group_name = "ugnesarakauskaite"
  }
}

variable "resources" {
  default = {
    "adjectives" = 1
    "adverbs" = 2
    "nouns" = 3
    "verbs" = 4
  }
}

variable "configuration3" {
  default = {
    "StorageConnectionString" = "DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName=ugnestorageaccount;AccountKey=402fSd5BmMpkDz4L+TwUlrlPdAH2nECFP/FC6WBOMl+ff3NVVES1TvW2nNcCHR+1s1B/+lsRsrNdmKDCNeqMtw=="
    "StorageAccountName"      = "ugnestorageaccount"
    "StorageAccountKey"       = "402fSd5BmMpkDz4L+TwUlrlPdAH2nECFP/FC6WBOMl+ff3NVVES1TvW2nNcCHR+1s1B/+lsRsrNdmKDCNeqMtw=="
  }
}

variable "configuration4" {
  default = {
    "lengthServiceURL" = "https://ugne-webapp2.azurewebsites.net/length"
    "wordsServiceURL"  = "https://ugne-webapp3.azurewebsites.net/words"
  }
}