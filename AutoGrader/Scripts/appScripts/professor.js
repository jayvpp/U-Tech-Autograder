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
    $scope.statement = "Type question...";
    $scope.testName = "";
    $scope.testMaxScore = "";
    $scope.testPassingGrade = "";
    $scope.add = function () {
      
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
        };
        return question;
    }


    function retriveBoolenQuestion() {
        var checkValues = $(".tfcheck");

        var result = true;

        if (!($(checkValues[0]).is(':checked')))
            result = false;

        var question = buildBoolenQuestion($scope.statement, result);

        return question;
    };

    function retriveSingleChoiceQuestion()
    {
        var optionsCount = $(".sscheck").size();

        var checkValues = $(".sscheck");
        var textValues = $(".sstext");

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
                                         correctAnswer);
        return question;
    };

    function retriveMultipleChoiceQuestion() {
        console.log("entering retriveMultipleChoiceQuestion");

        var optionsCount = $(".mscheck").size();
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
                                                    correctAnswers)

        return question;
    };

    function retriveShortAnswerQuestion()
    {
        var answer = $(".shortanswercheck").val().toLowerCase();
        //check that answer is one world,if not return notification to user
        var question = buildShortAnswerQuestion($scope.statement, answer);
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

    $scope.submitTest = function () {
        //error = false;

        //if ($scope.testName == "") {
        //    $scope.alerts.push("You must enter a Test Name before submitting");
        //    error = true;
        //}
        //if ($scope.testMaxScore == "") {
        //    $scope.alerts.push("You must enter a Test Maximun Score value before submitting");
        //    error = true;
        //}  
        //if ($scope.testPassingGrade == ""){
        //    $scope.alerts.push("You must enter a Test Passing Grade value before submitting");
        //    error = true;
        //}
        //if (error) {
        //    $timeout(function () { $scope.alerts.splice(0, $scope.alerts.length); }, 5000);
        //    return
        //}
        alert("ccalling http");
        var request = $http(
                {
                    method: "post",
                    dataType: "json",
                    url: "/Test/CreateMultipleChoiceQuestion/",
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


    $scope.addQuestion = function () {

        //WE CAN REFACTOR THE SCOPE.QUESTIONS.PUSH SO WE DONT NEED TO CALL IN ON EACH IF
        if ($scope.selected == "MultiSelect") {
            var question = retriveMultipleChoiceQuestion();
            $scope.allQuestions.push(question);
            $scope.multipleChoiceQuestions.push(question);
            return;
        }

        if ($scope.selected == "SingleSelect") {
            var question = retriveSingleChoiceQuestion();
            $scope.allQuestions.push(question);
            $scope.singleChoiceQuestions.push(question);
            return;
        }

        if ($scope.selected == "TrueFalse") {
            var question = retriveBoolenQuestion()
            $scope.allQuestions.push(question);
            $scope.booleanQuestion.push(question);
            return;
        }

        if ($scope.selected == "ShortAnswer") {
            var answer = $(".shortanswercheck").val().toLowerCase();
            //check that answer is one world,if not return notification to user
            var question = retriveShortAnswerQuestion();
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