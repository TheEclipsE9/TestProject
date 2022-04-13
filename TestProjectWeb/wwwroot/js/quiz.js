$(document).ready(function () {
    $('.check-quiz').click(function () {
        console.log("check!")

        let index = 0;
        while (true) {
            let userAnswer = $(`.quiz-userAnswer-${index}`).val();
            if (typeof (userAnswer) === 'undefined') {
                break;
            }
            let correctAnswer = $(`.quiz-correctAnswer-${index}`).val();
            
            if (userAnswer == correctAnswer) {
                $(`.quiz-ask-${index}`).css("color", "green")
                console.log("correct!")
            }
            else {
                $(`.quiz-ask-${index}`).css("color", "red")
                console.log("uncorrect!")
            }
            console.log(index);
            index++;
        }
    });
});