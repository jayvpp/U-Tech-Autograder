var app = angular.module("autoTesting", []); 
app.controller("createTestController", function ($scope, $http, $timeout) {
    $scope.numberQuestions = [1,2,3];
    $scope.allQuestions = []
    $scope.alerts = []
    //types of questions
    $scope.singleChoiceQuestions = []
    $scope.multipleChoiceQuestions = []
    $scope.booleanQuestions = []
    $scope.shortAnswerQuestions = []
    $scope.paragraphQuestions = []

    $scope.selected = "MultiSelect";
    $scope.statement = "";
    $scope.testName = "";
    $scope.testMaxScore = "";
    $scope.testPassingGrade = "";
    $scope.add = function () {
      
    }
    function buildBoolenQuestion(statement,answer, score) {
        var question = {
            "type": "booleanquestion",
            "score": score,
            "statement": statement,
            "answer" : answer
        };
        return question;
    }

    function buildSingleChoiceQuestion(statement, posibleAnswers, correctAnswer, score)
    {
        var question = {
            "type": "singlechoice",
            "score" : score,
            "statement": statement,
            "posibleAnswers": posibleAnswers,
            "correctAnswer" : correctAnswer
        };
        return question;
    }

    function buildMultipleChoiceQuestion(statement, posibleAnswers, correctAnswers, score) {
        var question = {
            "type": "multiplechoice",
            "score": score,
            "statement": statement,
            "posibleAnswers": posibleAnswers,
            "correctAnswers": correctAnswers
        };
        return question;
    }

    function buildShortAnswerQuestion(statement, answer, score)
    {
        var question = {
            "type": "shortanswer",
            "score": score,
            "statement": statement,
            "answer": answer
        };
        return question;
    }

    function buildParagraphAnswerQuestion(statement, paragraphAnswer, score) {
        var question = {
            "type": "paragraph",
            "score": score,
            "statement": statement,
        };
        return question;
    }


    function retriveBoolenQuestion() {
        var checkValues = $(".tfcheck");
        var result = true;
        var score = $("#testScore").val();

        if (!($(checkValues[0]).is(':checked')))
            result = false;

        var question = buildBoolenQuestion($scope.statement, result, score);

        return question;
    };

    function retriveSingleChoiceQuestion()
    {
        var optionsCount = $(".sscheck").size();
        var checkValues = $(".sscheck");
        var textValues = $(".sstext");
        var score = $("#testScore").val();

        var posibleAnswers = [];
        var correctAnswer = "";

        for (i = 0 ; i < optionsCount; i++) {
            var posOption = $(textValues[i]).val();
            posibleAnswers.push(posOption);
            if ($(checkValues[i]).is(':checked'))
                correctAnswer = posOption
  
        }

        var question = buildSingleChoiceQuestion($scope.statement,
                                                 posibleAnswers,
                                                 correctAnswer,score);
        return question;
    };

    function retriveMultipleChoiceQuestion() {
        console.log("entering retriveMultipleChoiceQuestion");

        var optionsCount = $(".mscheck").size();
        var score = $("#testScore").val();

        console.log("count " + optionsCount);
        var checkValues = $(".mscheck");
        var textValues = $(".mstext");

        var posibleAnswers = [];
        var correctAnswers = [];

        for (i = 0 ; i < optionsCount; i++) {
            var posOption = $(textValues[i]).val();
            posibleAnswers.push(posOption);
            if ($(checkValues[i]).is(':checked'))
                correctAnswers.push(posOption)
        }

        var question = buildMultipleChoiceQuestion($scope.statement,
                                                   posibleAnswers,
                                                   correctAnswers,
                                                   score)

        return question;
    };

    function retriveShortAnswerQuestion()
    {
        var answer = $(".shortanswercheck").val().toLowerCase();
        var score = $("#testScore").val();
        //check that answer is one world,if not return notification to user
        var question = buildShortAnswerQuestion($scope.statement, answer, score);
        return question;
    };

    function retriveParagraphAnswerQuestion() { };

    $scope.addOption = function () {
        $scope.numberQuestions.push($scope.numberQuestions.length + 1);
    };

    $scope.removeOption = function () {
        if ($scope.numberQuestions.length <= 2) {
            alert("You have to have at least two options");
            return;
        }
        $scope.numberQuestions.pop();
    };

    $scope.cleanAlers = function () {
        $scope.alerts.splice(0, $scope.alerts.length);
    };

    function cleanAlerts()
    {
        $timeout(function () { $scope.alerts.splice(0, $scope.alerts.length); }, 5000);
    }

    $scope.submitTest = function () {
        error = false;

        if ($scope.testName == "") {
            $scope.alerts.push("You must enter a Test Name before submitting");
            error = true;
        }
        if ($scope.testMaxScore == "") {
            $scope.alerts.push("You must enter a Test Maximun Score value before submitting");
            error = true;
        }  
        if ($scope.testPassingGrade == ""){
            $scope.alerts.push("You must enter a Test Passing Grade value before submitting");
            error = true;
        }
        if (error) {
            cleanAlerts();
            return
        }
       
        var request = $http(
                {
                    method: "post",
                    dataType: "json",
                    url: "/Test/Create/",
                    data: {
                     
                        testName: $scope.testName,
                        testMaxScore: $scope.testMaxScore,
                        testPassingGrade: $scope.testPassingGrade,
                        multipleChoiceQuestions: $scope.multipleChoiceQuestions,
                        singleChoiceQuestions: $scope.singleChoiceQuestions,
                        booleanQuestions: $scope.booleanQuestion,
                        shortAnswerQuestions: $scope.shortAnswerQuestion
                        //paragraphQuestions : $Scope.paragraphQuestion
                    }
                }
            );
        return;

    };


    function isValidQuestion(questionType, question) {
        if (question.statement == "" || question.score == "")
            return false;

        if (questionType == "MultiSelect" || questionType == "SingleSelect") {
            console.log("enetring cheking singl multi select");
            console.log(JSON.stringify(question));
            if (question.posibleAnswers.length < 2) return false;
            for (i = 0 ; i < question.posibleAnswers.length ; i++) {
                if (question.posibleAnswers[i] == "")
                { return false; }
            }
        }
        if (questionType == "MultiSelect") {
            if (question.correctAnswers.length <= 0) return false;
            for (i = 0 ; i < question.correctAnswers.length ; i++) {
                if (question.correctAnswers[i] == "")
                { return false; }
            }
            return true;
        }

        if (questionType == "SingleSelect") {
            return question.correctAnswer != ""
        }

        if (questionType == "TrueFalse") {
            //need no checking, html will enforce correctness.
            return true;
        }

        if (questionType == "ShortAnswer")
            return question.answer != ""

    }

    function displayErrorFillingQuestion() {
        $scope.alerts.push("Error Adding Question, Make sure you enter all necesary information");
        cleanAlerts();
    }

    $scope.addQuestion = function () {

        //WE CAN REFACTOR THE SCOPE.QUESTIONS.PUSH SO WE DONT NEED TO CALL IN ON EACH IF
        if ($scope.selected == "MultiSelect") {
            var question = retriveMultipleChoiceQuestion();
            if (!isValidQuestion("MultiSelect", question)) {
                displayErrorFillingQuestion();
                return;
            }
            $scope.allQuestions.push(question);
            $scope.multipleChoiceQuestions.push(question);
            return;
        }

        if ($scope.selected == "SingleSelect") {
            var question = retriveSingleChoiceQuestion();
            if (!isValidQuestion("SingleSelect", question)) {
                displayErrorFillingQuestion();
                return;
            }
            $scope.allQuestions.push(question);
            $scope.singleChoiceQuestions.push(question);
            return;
        }

        if ($scope.selected == "TrueFalse") {
            var question = retriveBoolenQuestion();
            if (!isValidQuestion("TrueFalse", question)) {
                displayErrorFillingQuestion();
                return;
            }
            $scope.allQuestions.push(question);
            $scope.booleanQuestion.push(question);
            return;
        }

        if ($scope.selected == "ShortAnswer") {
            var answer = $(".shortanswercheck").val().toLowerCase();
            //check that answer is one world,if not return notification to user
            var question = retriveShortAnswerQuestion();
            if (!isValidQuestion("ShortAnswer", question)) {
                displayErrorFillingQuestion();
                return;
            }
            $scope.allQuestions.push(question);
            $scope.shortAnswerQuestion.push(question);
            return;
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