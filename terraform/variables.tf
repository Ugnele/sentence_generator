variable "my_name" {
  default = "ugne"
}

variable "location" {
  default = "uksouth"
}

variable "rg_name" {
  default = "ugnesarakauskaite"
}

variable "resources" {
  default = {
    "adjectives" = 1
    "adverbs" = 2
    "nouns" = 3
    "verbs" = 4
  }
}

variable "StorageConnectionString" {
  sensitive = true
  type      = string
}

variable "StorageAccountKey" {
  sensitive = true
  type      = string
}