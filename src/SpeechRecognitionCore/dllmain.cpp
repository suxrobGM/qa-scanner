// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#define DLL_EXPORT __declspec(dllexport)

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

extern "C" {
	 
	DLL_EXPORT SpeechRecognition::AzureSpeech* CreateAzureSpeech(const char* subscriptionKey, const char* regionName)
	{
		return new SpeechRecognition::AzureSpeech(subscriptionKey, regionName);
	}
		
	DLL_EXPORT void DisposeAzureSpeech(SpeechRecognition::AzureSpeech* object)
	{
		if (object != nullptr)
		{
			delete object;
			object = nullptr;
		}
	}
	
	DLL_EXPORT void RecognizeFromMicrophone(SpeechRecognition::AzureSpeech* object)
	{
		if (object == nullptr)
			return;
		
		object->RecognizeFromMicrophone();
	}
	
	DLL_EXPORT void RecognizeFromWawFile(  SpeechRecognition::AzureSpeech* object,
								const char* fileName,
								bool saveToOutputFile = false,
								const char* outputFileName = "transcript.txt"
							 )
	{
		if (object == nullptr)
			return;

		object->RecognizeFromWawFile(fileName, saveToOutputFile, outputFileName);
	}

	DLL_EXPORT char* GetOutputResult(SpeechRecognition::AzureSpeech* object)
	{
		return const_cast<char*>(object->GetOutputResult().c_str());
	}
}