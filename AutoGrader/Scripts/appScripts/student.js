var app = angular.module("autoTesting", []); 
app.controller("takeTestController", function ($scope, $http) {

    $scope.init = function (test)
    {
        $scope.test = test;
        $scope.AllQuestion = [];
   
        $scope.TestResponse = {
            'TestId': $scope.test.Id,
            'Responses': []
        }

        for (i = 0; i < $scope.test.MultipleChoiceQuestions.length; i++)
            $scope.AllQuestion.push($scope.test.MultipleChoiceQuestions[i])

        for (i = 0; i < $scope.test.SingleChoiceQuestions.length; i++)
            $scope.AllQuestion.push($scope.test.SingleChoiceQuestions[i])

        for (i = 0; i < $scope.test.BooleanQuestions.length; i++)
            $scope.AllQuestion.push($scope.test.BooleanQuestions[i])

        for (i = 0; i < $scope.test.ShortAnswerQuestions.length; i++)
            $scope.AllQuestion.push($scope.test.ShortAnswerQuestions[i])

        //for (mcq in $scope.test.MultipleChoiceQuestions)
        //    $scope.AllQuestion.push(mcq);

        //for (mcq in $scope.test.SingleChoiceQuestions)
        //    $scope.AllQuestion.push(mcq);

        //for (mcq in $scope.test.BooleanQuestions)
        //    $scope.AllQuestion.push(mcq);

        //for (mcq in $scope.test.ShortAnswerQuestions)
        //    $scope.AllQuestion.push(mcq);


    }
    function CheckAllQuestionAreAnswered()
    {
        return true;
    }

    function retriveTestResponses() {
        
        var questions = $scope.AllQuestion;
        
        for (i = 0 ; i < questions.length; i++) {
            var qId = questions[i].Id;

            var selector = ".question" + qId;

            var currentQuestion = questions[i];
            
            var qResponses = [];

            if (currentQuestion.Type == "singlechoice" || currentQuestion.Type == "multiplechoice") {
                    
                var numbOptions = currentQuestion.PosibleAnswers.length;
                for (k = 0; k < numbOptions; k++) {
                    var text = $($(selector)[k]).val();
                   
                    if (currentQuestion.Type == "singlechoice")
                        checked = $($(selector).filter(".singleselect")[k]).prop('checked');
                    else
                        checked = $($(selector).filter(".multiselect")[k]).prop('checked');
                    
                    if (checked)
                        qResponses.push(text);
                }

                $scope.TestResponse.Responses.push({
                    "QuestionId": qId,
                    "Responses": qResponses
                }
                );
            }
            

            if (currentQuestion.Type == "shortanswer") {
                var qResponse = $($(selector).filter(".shortanswer")[0]).val()

                $scope.TestResponse.Responses.push({
                    "QuestionId": qId,
                    "Responses": qResponse
                });
            }

            if (currentQuestion.Type == "booleanquestion") {
                var qResponse = $($(selector).filter(".truefalse")[0]).prop("checked") == true

                $scope.TestResponse.Responses.push({
                    "QuestionId": qId,
                    "Responses": qResponse
                });
            }
        };
        
    }

    function submitTestForGrading()
    {

        alert(JSON.stringify($scope.TestResponse));

        $http(
                {
                    method: "post",
                    dataType: "json",
                    url: "/Professor/Grading",
                    data: $scope.TestResponse
                }
            ).then(function successCallback(response) {
                //window.location.pathname = "/Professor/Index";
            }, function errorCallback(response) {
                $scope.alerts("Error submitting tests");
            });

    }

    $scope.submitTest = function () {
        $scope.TestResponse.Responses = [];
        if (!CheckAllQuestionAreAnswered())
        {
            alert("Cannot submit, you need to enter all answers");
            return;
        }

        retriveTestResponses();

        submitTestForGrading();
    }

});