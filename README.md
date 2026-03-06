<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/1166713046/25.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1323069)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# PDF Document API - Convert DOCX to PDF in a Chiseled .NET Docker Container

This example uses DevExpress Word Processing Document API to generate a DOCX document and save it to a PDF file. The project is designed to run in a Linux chiseled runtime image (`aspnet:10.0-noble-chiseled-composite-extra`) and demonstrates the following actions:

- Use DevExpress PDF Document API in a container
- Use the Skia drawing engine (`DevExpress.Drawing.Skia`)
- Register custom `.ttf` fonts from the app directory
- Stream binary PDF output through standard output

## Build and run with Docker

Build image:

```bash
docker build -f CS/Dockerfile -t chiseled-docx2pdf CS
```

Run conversion (PDF is redirected to host file):

```bash
docker run --rm chiseled-docx2pdf CS/fontTest.docx > out.pdf
```

If your input file is outside the image, mount a host folder and pass a mounted path.

## Files to Review

- [Dockerfile](./CS/Dockerfile)
- [Program.cs](./CS/Program.cs)
- [ChiseledDocker.csproj](./CS/ChiseledDocker.csproj)

## Documentation

- [Use Office File API on Linux](https://docs.devexpress.com/OfficeFileAPI/401441/installation-guide/use-office-file-api-on-linux)
- [Dockerize an Office File API Application](https://docs.devexpress.com/OfficeFileAPI/401528/integration-guide/dockerize-an-office-file-api-app)

<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=office-file-api-dockerize-application-chiseled-image&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=office-file-api-dockerize-application-chiseled-image&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
