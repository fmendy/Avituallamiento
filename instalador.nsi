# nombre del instalador
OutFile "InstaladorAvituallamiento.exe"
 
# establecemos el escritorio como directorio de instalacion
InstallDir $DESKTOP
 
 #Cambiar el idioma
!include "MUI.nsh"
!insertmacro MUI_LANGUAGE "Spanish"

# mostar elegir directorio
 Page directory
 Page instfiles
# seccion del instalador
Section
 
	# definimos el directorio a donde vamos a extraer el test.txt
	SetOutPath "$INSTDIR"
	 
	# especificamos el archivo
	File /r "..\Avituallamiento"
	
	# Creamos el acceso en el escritorio
	CreateShortCut "$DESKTOP\Avituallamiento.lnk" "$INSTDIR\Avituallamiento\Avituallamiento\bin\Debug\Avituallamiento.exe"
	# Creamos el acceso en el menu
	CreateShortCut "$SMPROGRAMS\Avituallamiento.lnk" "$INSTDIR\Avituallamiento\Avituallamiento\bin\Debug\Avituallamiento.exe"
	 
	# definimos el desinstalador y su nombre
	 WriteUninstaller $INSTDIR\uninstaller.exe
	 
	# fin de la seccion con el instalador
SectionEnd

Section "Uninstall"
	 
	# Borramos primero el desinstalador
	Delete $INSTDIR\uninstaller.exe
	 
	# borramos el acceso directorio
	Delete "$DESKTOP\Avituallamiento.lnk"
	Delete "$SMPROGRAMS\Avituallamiento.lnk"
	
	#Borramos el lugar donde se instalo
	RMDir /r "$INSTDIR\Avituallamiento"
SectionEnd