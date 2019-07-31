#pragma once
#include "pch.h"
#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <speechapi_cxx.h>

using namespace std;
using namespace Microsoft::CognitiveServices::Speech;
using namespace Microsoft::CognitiveServices::Speech::Audio;

namespace SpeechRecognition
{
	class AzureSpeech
	{
	private:
		string _subscriptionKey;
		string _region;
		string _outputResult;
		string _outputFileName;		
		shared_ptr<SpeechConfig> _config;

	public:
		AzureSpeech(AzureSpeech* object)
		{
			this->_subscriptionKey = object->_subscriptionKey;
			this->_region = object->_region;
			this->_outputFileName = object->_outputFileName;
			this->_config = SpeechConfig::FromSubscription(_subscriptionKey, _region);
			this->_outputResult = "";
		}

		AzureSpeech(string subscriptionKey, string region)
		{
			this->_subscriptionKey = subscriptionKey;
			this->_region = region;
			this->_config = SpeechConfig::FromSubscription(subscriptionKey, region);
			this->_outputResult = "";
			this->_outputFileName = "transcript.txt";
		}

		AzureSpeech(string subscriptionKey, string region, string outputFileName)
		{
			this->_subscriptionKey = subscriptionKey;
			this->_region = region;
			this->_config = SpeechConfig::FromSubscription(subscriptionKey, region);
			this->_outputResult = "";
			this->_outputFileName = outputFileName;
		}

		void RecognizeFromMicrophone()
		{
			auto recognizer = SpeechRecognizer::FromConfig(_config);
			cout << "Say something...\n";

			auto result = recognizer->RecognizeOnceAsync().get();
			
			ostringstream out;
			if (result->Reason == ResultReason::RecognizedSpeech)
			{
				out << "RECOGNIZED: Text=" << result->Text << std::endl;
			}
			else if (result->Reason == ResultReason::NoMatch)
			{
				out << "NOMATCH: Speech could not be recognized." << std::endl;
			}
			else if (result->Reason == ResultReason::Canceled)
			{
				auto cancellation = CancellationDetails::FromResult(result);
				out << "CANCELED: Reason=" << (int)cancellation->Reason << std::endl;

				if (cancellation->Reason == CancellationReason::Error)
				{
					out << "CANCELED: ErrorCode=" << (int)cancellation->ErrorCode << std::endl;
					out << "CANCELED: ErrorDetails=" << cancellation->ErrorDetails << std::endl;
					out << "CANCELED: Did you update the subscription info?" << std::endl;
				}
			}

			_outputResult += out.str();
		}

		void RecognizeFromWavFile(string filePath)
		{
			auto recognizer = SpeechRecognizer::FromConfig(_config, AudioConfig::FromWavFileInput(filePath));

			// promise for synchronization of recognition end.
			promise<void> recognitionEnd;			

			recognizer->Recognized.Connect([this](const SpeechRecognitionEventArgs& e)
			{
				ostringstream out;

				if (e.Result->Reason == ResultReason::RecognizedSpeech)
				{
					out << "RECOGNIZED: Text=" << e.Result->Text << "\n";
						//<< "  Offset=" << e.Result->Offset() << "\n"
						//<< "  Duration=" << e.Result->Duration() << std::endl;					
				}
				else if (e.Result->Reason == ResultReason::NoMatch)
				{
					out << "NOMATCH: Speech could not be recognized." << std::endl;
				}

				_outputResult += out.str();
			});

			recognizer->Canceled.Connect([this, &recognitionEnd](const SpeechRecognitionCanceledEventArgs& e)
			{
				ostringstream out;
				out << "CANCELED: Reason=" << (int)e.Reason << std::endl;

				if (e.Reason == CancellationReason::Error)
				{
					out << "CANCELED: ErrorCode=" << (int)e.ErrorCode << "\n"
						<< "CANCELED: ErrorDetails=" << e.ErrorDetails << "\n"
						<< "CANCELED: Did you update the subscription info?" << std::endl;

					recognitionEnd.set_value(); // Notify to stop recognition.
				}

				_outputResult += out.str();
			});

			recognizer->SessionStopped.Connect([this, &recognitionEnd](const SessionEventArgs& e)
			{
				ostringstream out;
				out << "Session stopped.";
				_outputResult += out.str();
				recognitionEnd.set_value(); // Notify to stop recognition.
			});

			// Starts continuous recognition. Uses StopContinuousRecognitionAsync() to stop recognition.
			recognizer->StartContinuousRecognitionAsync().get();

			// Waits for recognition end.
			recognitionEnd.get_future().get();

			// Stops recognition.
			recognizer->StopContinuousRecognitionAsync().get();

			ofstream outFile;
			outFile.open(_outputFileName, ios::app);
			outFile << _outputResult;
			outFile.close();
		}

		string GetOutputResult()
		{
			return this->_outputResult;
		}

		string GetOutputFileName()
		{
			return this->_outputFileName;
		}

		~AzureSpeech()
		{
			/*ofstream outFile;
			outFile.open("SpeechRecognitionCore.log");
			outFile << "calling destructor" << endl;
			outFile << _outputResult << endl;
			outFile.close();*/
		}
	};
}