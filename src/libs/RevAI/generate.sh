dotnet tool install --global autosdk.cli --prerelease
rm -rf Generated
# Spec is manually maintained (combines STT, Sentiment Analysis, Topic Extraction, Language ID)
# Original STT-only spec from: https://raw.githubusercontent.com/APIs-guru/openapi-directory/main/APIs/rev.ai/v1/openapi.yaml
cp openapi.yaml openapi.yaml 2>/dev/null || true
autosdk generate openapi.yaml \
  --namespace RevAI \
  --clientClassName RevAIClient \
  --targetFramework net10.0 \
  --output Generated \
  --exclude-deprecated-operations
