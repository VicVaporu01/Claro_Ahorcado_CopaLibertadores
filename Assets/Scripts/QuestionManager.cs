using System;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    private List<Question> questionsList = new List<Question>();

    private void Start()
    {
        AddQuestionsToList();

        GameManager.Instance.PrepareQuestions(SendRandomQuestions());
    }

    private List<Question> SendRandomQuestions()
    {
        List<Question> randomQuestions = new List<Question>();

        for (int i = 0; i < 20; i++)
        {
            int randomIndex = UnityEngine.Random.Range(0, questionsList.Count);
            randomQuestions.Add(questionsList[randomIndex]);
            questionsList.RemoveAt(randomIndex);
        }

        return randomQuestions;
    }

    private void AddQuestionsToList()
    {
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1994?", "Velez"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1996?", "River"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1997?", "Cruzeiro"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1998?", "Vasco"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1999?", "Palmeiras"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2000?", "Boca"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2001?", "Boca"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2002?", "Olimpia"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2003?", "Boca"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2004?", "Caldas"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2005?", "SaoPaulo"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2007?", "Boca"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2011?", "Santos"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2013?", "Mineiro"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2014?", "Lorenzo"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2017?", "Gremio"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2018?", "River"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2019?", "Flamengo"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2020?", "Palmeiras"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2021?", "Palmeiras"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2022?", "Flamengo"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 2022?", "Fluminense"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1990?", "Olimpia"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1991?", "ColoColo"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1992?", "SaoPablo"));
        questionsList.Add(new Question("¿Qué club ha ganado más veces la Copa Libertadores?", "Independiente"));
        questionsList.Add(new Question("¿Qué club brasileño ganó la Libertadores en 2020?", "Palmeiras"));
        questionsList.Add(new Question("¿Qué equipo argentino ganó la Copa en 2018?", "River"));
        questionsList.Add(new Question("¿Qué país tiene más títulos de la Copa Libertadores?", "Argentina"));
        questionsList.Add(new Question("¿Qué club uruguayo ganó la primera edición en 1960?", "Peñarol"));
        questionsList.Add(new Question("¿Qué país ha ganado más veces la Libertadores?", "Brasil"));
        questionsList.Add(new Question("¿Qué equipo paraguayo ha ganado la Libertadores?", "Olimpia"));
        questionsList.Add(new Question("¿Qué jugador es el máximo goleador histórico?", "Zico"));
        questionsList.Add(new Question("¿Qué equipo ganó la final en 1992 y 1993?", "SaoPaulo"));
        questionsList.Add(new Question("¿Qué club chileno ha ganado la Copa?", "ColoColo"));
        questionsList.Add(new Question("¿Qué club argentino ha ganado 4 títulos de la Copa?", "River"));
        questionsList.Add(new Question("¿En qué año Boca Juniors ganó su primer título?", "1977"));
        questionsList.Add(new Question("¿Qué club ecuatoriano alcanzó la final en 1998?", "Barcelona"));
        questionsList.Add(new Question("¿Qué club peruano alcanzó la final en 1972?", "Universitario"));
        questionsList.Add(new Question("¿Qué equipo brasileño ganó la Copa en 2019?", "Flamengo"));
        questionsList.Add(new Question("¿Qué club colombiano ganó en 2016?", "Nacional"));
        questionsList.Add(new Question("¿Qué club paraguayo ganó 3 títulos de la Copa?", "Olimpia"));
        questionsList.Add(new Question("¿Qué jugador argentino es el máximo goleador de la Copa?", "Labruna"));
        questionsList.Add(new Question("¿Qué jugador ganó la Copa con River en 1986?", "Francescoli"));
        questionsList.Add(new Question("¿Qué equipo boliviano llegó a la final en 1963?", "Bolivar"));
        questionsList.Add(new Question("¿Qué club venezolano llegó a semifinales en 1999?", "Caracas"));
        questionsList.Add(new Question("¿Qué equipo mexicano fue finalista en 2001?", "CruzAzul"));
        questionsList.Add(new Question("¿En qué año se jugó la primera edición de la Copa?", "1960"));
        questionsList.Add(new Question("¿Qué club ganó 4 veces entre 1972 y 1983?", "Independiente"));
        questionsList.Add(new Question("¿Qué país sudamericano no tiene títulos de la Libertadores?", "Venezuela"));
        questionsList.Add(new Question("¿Qué club brasileño ganó el torneo en 2017?", "Gremio"));
        questionsList.Add(new Question("¿Qué club uruguayo ganó 3 títulos entre 1982 y 1987?", "Nacional"));
        questionsList.Add(new Question("¿En qué país se jugó la final de 2019?", "Peru"));
        questionsList.Add(new Question("¿Qué club boliviano ha sido semifinalista?", "Bolivar"));
        questionsList.Add(new Question("¿Qué jugador ganó 3 veces la Copa con Boca Juniors?", "Riquelme"));
        questionsList.Add(new Question("¿En qué año River Plate ganó la Copa por cuarta vez?", "2018"));
        questionsList.Add(new Question("¿Qué equipo paraguayo ganó su primer título en 1979?", "Olimpia"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1965?", "Independiente"));
        questionsList.Add(new Question("¿Qué equipo uruguayo ganó la Copa en 1988?", "Nacional"));
        questionsList.Add(new Question("¿Qué jugador brasileño es famoso por ganar la Copa en 1992?", "Rai"));
        questionsList.Add(new Question("¿Qué club ganó el título en 2006 y 2007?", "Boca"));
        questionsList.Add(new Question("¿En qué año Santos ganó su primera Copa?", "1962"));
        questionsList.Add(new Question("¿Qué club colombiano ganó por primera vez en 1989?", "Nacional"));
        questionsList.Add(new Question("¿Qué equipo brasileño fue campeón en 2005?", "SaoPaulo"));
        questionsList.Add(new Question("¿Qué país organizó la final en 2013?", "Paraguay"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1979 y 1980?", "Olimpia"));
        questionsList.Add(new Question("¿Qué equipo ecuatoriano fue finalista en 1998?", "Barcelona"));
        questionsList.Add(new Question("¿Qué club argentino ganó la Copa en 1978?", "Boca"));
        questionsList.Add(new Question("¿Qué club chileno ha llegado a la final?", "ColoColo"));
        questionsList.Add(new Question("¿Qué club ganó la final en 1992?", "SaoPaulo"));
        questionsList.Add(new Question("¿Qué equipo ganó la final en 2015?", "River"));
        questionsList.Add(new Question("¿Qué club brasileño ganó la Copa en 1999?", "Palmeiras"));
        questionsList.Add(new Question("¿Qué equipo paraguayo ha ganado 3 títulos?", "Olimpia"));
        questionsList.Add(new Question("¿Qué jugador argentino es el máximo goleador histórico?", "Labruna"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1997?", "Cruzeiro"));
        questionsList.Add(new Question("¿Qué equipo boliviano fue semifinalista en 1986?", "Bolivar"));
        questionsList.Add(new Question("¿Qué equipo colombiano ganó en 1989?", "Nacional"));
        questionsList.Add(new Question("¿Qué país ha sido anfitrión de la final en 2021?", "Brasil"));
        questionsList.Add(new Question("¿Qué equipo llegó a la final en 2001?", "Boca"));
        questionsList.Add(new Question("¿Qué club ganó la final en 2007?", "Boca"));
        questionsList.Add(new Question("¿Qué equipo brasileño ganó la Copa en 2013?", "Atletico"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1994?", "Velez"));
        questionsList.Add(new Question("¿Qué equipo ganó la Copa en 1989?", "Nacional"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1977?", "Boca"));
        questionsList.Add(new Question("¿Qué equipo ganó la final en 2021?", "Palmeiras"));
        questionsList.Add(new Question("¿Qué club colombiano ganó la Copa en 2016?", "Nacional"));
        questionsList.Add(new Question("¿Qué equipo boliviano alcanzó la final en 1963?", "Bolivar"));
        questionsList.Add(new Question("¿Qué club uruguayo ha ganado la Copa 3 veces?", "Nacional"));
        questionsList.Add(new Question("¿Qué equipo ganó la Copa en 1978?", "Boca"));
        questionsList.Add(new Question("¿Qué club brasileño ha ganado 4 títulos?", "SaoPaulo"));
        questionsList.Add(new Question("¿Qué equipo ganó la Copa en 1965?", "Independiente"));
        questionsList.Add(new Question("¿Qué club paraguayo ha sido finalista en varias ediciones?", "Olimpia"));
        questionsList.Add(new Question("¿Qué equipo ecuatoriano fue finalista en 1990?", "Barcelona"));
        questionsList.Add(new Question("¿Qué club ganó la Copa en 1993?", "SaoPaulo"));
        questionsList.Add(new Question("¿Qué equipo brasileño ganó la Copa en 1999?", "Palmeiras"));
        questionsList.Add(new Question("¿Qué club chileno fue campeón en 1991?", "ColoColo"));
        questionsList.Add(new Question("¿Qué equipo ganó la Copa en 1985?", "Argentinos"));
        questionsList.Add(new Question("¿Qué club argentino ganó la Copa en 1969?", "Estudiantes"));
        questionsList.Add(new Question("¿Qué equipo brasileño ha ganado más de 2 títulos?", "Gremio"));
        questionsList.Add(new Question("¿Qué club brasileño ganó la Copa en 1983?", "Gremio"));
        questionsList.Add(new Question("¿Qué club argentino ha sido finalista en más de 10 ocasiones?", "River"));
    }
}

[Serializable]
public class Question
{
    public string questionText;
    public string questionAnswer;

    public Question(string questionText, string questionAnswer)
    {
        this.questionText = questionText;
        this.questionAnswer = questionAnswer;
    }
}