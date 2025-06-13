# VOSK IMPLEMENTATION GUIDE
This guide will show where to put the files in order to implement vosk plugin into an already existing unity project

## Streaming Assets
Streaming assets will conain all the models used by vosk in .zip format.<br>

⚠️ **IMPORTANT:** This MUST  be put like `Assets/StreamingAssets/vosk-model.zip`, the folder has to be named `StreamingAssets` or it won't work.

You can find other vosk models [here](https://alphacephei.com/vosk/models)

## Vosk
This folder contains a bunch of dependencies that the base scripts use, just put it in the `Assets` folder

## Plugins
This folder contsins the plugin for both android and windows (for testing in the editor), insert them in the `Assets` folder, or insert the content in the `Assets/Plugins` if you already have one

## Scripts
This folder contains all the base scripts that need to be used in order to implement vosk:
- `VoiceProcessor.cs`: Handles microphone management (e.g., you can set which microphone to use).
- `VoskSpeechToText.cs`: Uses the provided model to perform speech-to-text; you can specify the maximum number of alternatives or even provide a list of keywords to search for.
- `RecognitionResult.cs`: Encapsulates the results provided by `VoskSpeechToText.cs`, displaying the detected text along with its confidence.
- `STTManager.cs`: This is a script home made that interfaces with vosk's scripts in order to implement the Speech To Text in the project without changing the plugin's scripts.
- `VoskResultText.cs`: (OPTIONAL) Inserts the detected results into a UI component of the project.<br>
📝 **Note:** this script isn't really that usefull, it's actually better making one of your own to have some more freedome.

<br>

# TROUBLESHOOTING 🔧
- If you notice that the first time running the it takes a while to load, it's completly normal and it won't do that anymore for the other times that you build that app.
- If an exception about **Ionic.zip** non being found ore somehting about the zip package, try moving the `zip` folder inside `Assets/Vosk/` into the `Asset` folder and then back in the Vosk folder. If the problem persist leave it in the `Assets` folder.
