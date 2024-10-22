async function SetQuestion() {
    try {
        let questionText = await ReadFile("questions.txt");

        if (questionText === undefined)
            {
                if (question < 1)
                {
                    question ++;
                }
                else{
                    question --;
                    End();
                }
            }
        else
        {
            document.getElementById("Question").innerHTML = "Question " + question + ": " + questionText;
        }

        SetAnswers();

    } catch (error) {
        console.error("Error setting question:", error);
    }
}

async function SetAnswers()
{
    let answerText = await ReadFile("answers.txt");

    answerText = answerText.split(",");

    for (i=1; i <= 4; i++)
    {
        document.getElementById("b" + i).innerHTML = answerText[i-1];
    }
}

async function ReadFile(filename) {
    const filePath = "../../../TextFiles/McQuiz/" + filename;

    try {
        let response = await fetch(filePath);

        if (!response.ok) {
            throw new Error("Network response was not ok " + response.statusText);
        }

        let data = await response.text();
        // Assuming \r or \n line breaks, adjust split as needed

        let lines = data.split("\r\n"); // Or "\n" if it's Unix-style line breaks

        return lines[question - 1]; // Return the specific line for the current question
    } catch (error) {
        console.error("Error reading file:", error);
    }
}

function NextQuestion()
{
    question ++;
    SetQuestion();
    SetAnswers();
}

function PreviousQuestion()
{
    question --;
    SetQuestion();
    SetAnswers();
}

question = 1;

window.onload = SetQuestion;