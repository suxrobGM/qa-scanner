// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <comutil.h>
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
	 
	DLL_EXPORT SpeechRecognition::AzureSpeech* __stdcall CreateAzureSpeech(const char* subscriptionKey, const char* regionName)
	{
		return new SpeechRecognition::AzureSpeech(subscriptionKey, regionName);
	}
		
	DLL_EXPORT void __stdcall DisposeAzureSpeech(SpeechRecognition::AzureSpeech* object)
	{
		if (object != nullptr)
		{
			delete object;
		}
	}
	
	DLL_EXPORT void __stdcall RecognizeFromMicrophone(SpeechRecognition::AzureSpeech* object)
	{
		if (object == nullptr)
			return;
		
		object->RecognizeFromMicrophone();
	}
	
	DLL_EXPORT void __stdcall RecognizeFromWavFile(SpeechRecognition::AzureSpeech* object, const char* filePath)
	{
		if (object == nullptr)
			return;

		object->RecognizeFromWavFile(filePath);
	}

	DLL_EXPORT BSTR __stdcall GetOutputResult(SpeechRecognition::AzureSpeech* object)
	{
		string outputText = object->GetOutputResult();
		wstring woutputText(outputText.begin(), outputText.end());

		return SysAllocString(woutputText.c_str());
	}
}