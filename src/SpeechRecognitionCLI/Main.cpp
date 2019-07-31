#include <iostream>
#include "azure_speech.h"
using namespace std;
using namespace SpeechRecognition;

int main(int argc, char** argv)
{
	if (argc <= 1)
	{
		cout << "No arguments, please provide arguments \n";
		return 1;
	}

	string subscriptionKey, region;

	for (size_t i = 1; i < argc; i++)
	{
		string arg = string(argv[i]);

		if (argv[i + 1] != nullptr && arg == "-k" || arg == "--key")
		{
			subscriptionKey = string(argv[i + 1]);
			cout << "Subscription Key: " << subscriptionKey << endl;
		}

		if (argv[i + 1] != nullptr && arg == "-r" || arg == "--region")
		{
			region = string(argv[i + 1]);
			cout << "Region: " << region << endl;
		}
	}

	string wavFilePath = "C:\\Users\\suxrobgm\\source\\repos\\QA_Scanner\\src\\TestSpeechRecognition\\bin\\Debug\\netcoreapp2.2\\system_recorded_audio.wav";
	auto speech = make_shared<AzureSpeech>(subscriptionKey, region);
	speech->RecognizeFromMicrophone();
	//speech->RecognizeFromWawFile(wavFilePath);
	//speech->SpeechContinuousRecognitionWithPullStream(wavFilePath);
	cout << speech->GetOutputResult();

	cout << "Please press a key to continue.\n";	
	cin.get();
	return 0;
}
