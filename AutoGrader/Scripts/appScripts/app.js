﻿var app = angular.module("autoTesting", []); 
app.controller("testController", function ($scope) {
    //$scope.types = ["MultiSelect", "SingleSelect", "TrueFlase", "Paragraph", "ShortAnswer"];
    $scope.questions = []
    $scope.selected = "MultiSelect";
    $scope.statement = "Type question...";

    $scope.add = function () {
        $scope.carname.push(6);

    }
    function buildBoolenQuestion(statement,answer) {
        var question = {
            "type": "booleanquestion",
            "statement": statement,
            "answer" : answer
        };
        return question;
    }

    function buildSingleChoiceQuestion(statement, posibleAnswers, correctAnswer)
    {
        var question = {
            "type": "singlechoice",
            "statement": statement,
            "posibleAnswers": posibleAnswers,
            "correctAnswer" : correctAnswer
        };
        return question;
    }

    function buildMultipleChoiceQuestion(statement, posibleAnswers, correctAnswers) {
        var question = {
            "type": "multiplechoice",
            "statement": statement,
            "posibleAnswers": posibleAnswers,
            "correctAnswers": correctAnswers
        };
        return question;
    }

    function buildShortAnswerQuestion(statement, answer)
    {
        var question = {
            "type": "shortanswer",
            "statement": statement,
            "answer": answer
        };
        return question;
    }

    function buildParagraphAnswerQuestion(statement, paragraphAnswer) {
        var question = {
            "type": "paragraph",
            "statement": statement,
            "paragraphAnswer": paragraphAnswer
        };
        return question;
    }

    $scope.addQuestion = function () {
   
        //WE CAN REFACTOR THE SCOPE.QUESTIONS.PUSH SO WE DONT NEED TO CALL IN ON EACH IF
        if ($scope.selected == "MultiSelect")
        {
            var optionsCount = $(".mscheck").size();

            var checkValues = $(".mscheck");
            var textValues =  $(".mstext");

            var posibleAnswers = [];
            var correctAnswers = [];

            for (i = 0 ; i < optionsCount; i++)
            {
                var posOption = $(textValues[i]).val();
                posibleAnswers.push(posOption);
                if ($(checkValues[i]).is(':checked'))                
                    correctAnswers.push(posOption)
            }

            var question =  buildMultipleChoiceQuestion("holamundo",
                                                posibleAnswers,
                                                correctAnswers)
            $scope.questions.push(question);
            return;

        }

        if ($scope.selected == "SingleSelect")
        {
            var optionsCount = $(".sscheck").size();
            
            var checkValues = $(".sscheck");
            var textValues = $(".sstext");
            
            var posibleAnswers = [];
            var correctAnswer = "";

            for (i = 0 ; i < optionsCount; i++) {
                var posOption = $(textValues[i]).val();
                posibleAnswers.push(posOption);
                if ($(checkValues[i]).is(':checked')) {
                    correctAnswer = posOption
                    break;
                }
            }

            var question = buildSingleChoiceQuestion($scope.statement,
                                             posibleAnswers,
                                             correctAnswer);
            
            $scope.questions.push(question);
            return;
        }

        if ($scope.selected == "TrueFalse")
        {
            var checkValues = $(".tfcheck");
            
            var result = true;

            if (!($(checkValues[0]).is(':checked')))
                result = false;
            
            var question = buildBoolenQuestion($scope.statement, result);

            $scope.questions.push(question);
            return;
        }

        if ($scope.selected == "ShortAnswer")
        {
            var answer = $(".shortanswercheck").val().toLowerCase();
            //check that answer is one world,if not return notification to user
            var question = buildShortAnswerQuestion($scope.statement, answer);
            $scope.questions.push(question);
        }

    };



    $scope.inc = function () {
        $scope.questions = getArray();
    };

    function getArray() {
        $k = $scope.questions.length + 1
        $scope.questions = []
        console.log($k)
        for ($i = 0 ; $i < $k; $i++)
            $scope.questions.push($i);
    };
});