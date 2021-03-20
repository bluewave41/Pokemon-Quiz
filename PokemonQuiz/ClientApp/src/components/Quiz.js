import React, { useState, useEffect } from 'react';

const Quiz = (props) => {
    const [question, setQuestion] = useState('');
    const [showQuiz, setShowQuiz] = useState(false);
    const [message, setMessage] = useState('Welcome to Pokemon Quiz! Click start to begin.');
    const [buttonText, setButtonText] = useState('Start');
    const [answer, setAnswer] = useState('');
    const [error, setError] = useState('');
    const [isAdmin, setIsAdmin] = useState(false);
    const [isLoaded, setIsLoaded] = useState(false);

    useEffect(() => {
        async function getUserInfo() {
            const response = await fetch('/user/getAdmin');
            if (response.ok) {
                const data = await response.json();
                setIsAdmin(data);
                setIsLoaded(true);
            }
        }
        getUserInfo();
    }, []);

    const getQuestion = async (e) => {
        const response = await fetch('/api/question');
        setMessage('');
        setAnswer('');
        if (response.ok) {
            setQuestion(await response.text());
            return true;
        }
        else {
            return false;
        }
    }

    const onButtonClick = async (e) => {
        if (!showQuiz) { //start quiz
            const response = await getQuestion();
            if (response) {
                setShowQuiz(true);
                setButtonText('Submit');
            }
            else {
                setError("An error occured.");
            }
        }
        else { //submit answer
            const options = {
                method: "POST",
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(answer)
            }

            const response = await fetch('/api/answer', options);

            if (response.ok) {
                setQuestion('');
                setShowQuiz(false);
                setButtonText('Next');
                setError('');
            
                const data = await response.json();
                if (data.correct) {
                    setMessage(`Thats correct! Your record is now ${data.correctAnswers}/${data.correctAnswers + data.incorrectAnswers}.`);
                }
                else if (!data.correct) {
                    setMessage(`Oh no that isn't right! The correct answer was ${data.correctAnswer}. Your record is now ${data.correctAnswers}/${data.correctAnswers+data.incorrectAnswers}.`);
                }
            }
        }
    }

    const onChange = (e) => {
        setAnswer(e.target.value);
    }

    const getAnswer = async (e) => {
        const response = await fetch('/api/answer');
        if (response.ok) {
            const data = await response.text();
            console.log(data);
            setError(data);
        }
    }

    if (!isLoaded) {
        return null;
    }

    return (
        <div>
            <h1>Pokemon Quiz</h1>
            {question ?
                <>
                    <div>{question}</div>
                    <input type="text" name="answer" placeholder="Answer" value={answer} onChange={onChange} />
                    { isAdmin ? <button onClick={getAnswer}>Get Answer</button> : null}
                </>
                : <h3>{message}</h3>
            }
            <p>{error}</p>
            <button onClick={onButtonClick}>{buttonText}</button>
            
        </div>
    )
}

export default Quiz;