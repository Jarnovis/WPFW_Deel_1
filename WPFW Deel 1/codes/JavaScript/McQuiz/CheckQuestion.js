let score = 0;
let maxScore = 0;

async function check(answer)
{
    let rightAnswer = await ReadFile("rightAnswer.txt");
    console.log(rightAnswer + " " + answer.innerHTML + rightAnswer == answer.innerHTML);

    if (rightAnswer == answer.innerHTML)
    {
        console.log("YES");
        score ++;
    }
    
    maxScore ++;

    NextQuestion();
}

function End()
{
    alert("Score: " + score + "/" + maxScore);
}
