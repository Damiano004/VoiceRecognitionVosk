# VOSK IMPLEMENTATION GUIDE
This guide will show where to put the files in order to implement vosk plugin into an already existing unity project

## Streaming Assets
Streaming assets will conain all the models used by vosk in .zip format.<br>

⚠️ **IMPORTANT:** This MUST  be put like `Assets/StreamingAssets/vosk-model.zip`, the folder has to be named `StreamingAssets` or it won't work.

## Vosk
This folder contains a bunch of dependencies that the base scripts use, just put them in the `Assets` folder

## Plugins
This folder contsins the plugin for both android and windows (for testing in the editor), insert them in the `Assets` folder, or insert the content in the `Assets/Plugins` if you already have one

## Scripts
This folder contains all the base scripts that need to be used in order to implement vosk:
- `VoiceProcessor.cs`: Handles microphone management (e.g., you can set which microphone to use).
- `VoskSpeechToText.cs`: Uses the provided model to perform speech-to-text; you can specify the maximum number of alternatives or even provide a list of keywords to search for.
- `RecognitionResult.cs`: Encapsulates the results provided by `VoskSpeechToText.cs`, displaying the detected text along with its confidence.
- `VoskResultText.cs`: Inserts the detected results into a UI component of the project.