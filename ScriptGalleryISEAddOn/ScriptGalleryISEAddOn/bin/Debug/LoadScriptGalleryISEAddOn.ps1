# ---------------------------------------------------
# Script: C:\Users\stefstr\Documents\GitHub\PowerShell\ScriptGalleryISEAddOn\ScriptGalleryISEAddOn\ScriptGalleryISEAddOn\bin\Debug\LoadScriptGalleryISEAddOn.ps1
# Version: 0.1
# Author: Stefan Stranger
# Date: 07/18/2014 17:04:10
# Description:
# Comments:
# ---------------------------------------------------

add-type -path "C:\Users\stefstr\Documents\GitHub\PowerShell\ScriptGalleryISEAddOn\ScriptGalleryISEAddOn\ScriptGalleryISEAddOn\bin\Debug\ScriptGalleryISEAddOn.dll"

$psISE.CurrentPowerShellTab.VerticalAddOnTools.Add('ScriptGalleryUpload', [ScriptGalleryISEAddOn.ScriptGallery], $true)

