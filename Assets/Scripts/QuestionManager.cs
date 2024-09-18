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
        questionsList.Add(new Question("¿Qué club ganó la Champions League en 2020?", "Bayern"));
        questionsList.Add(new Question("¿Qué selección tiene como apodo \"Los Leones Indomables\"?", "Camerun"));
        questionsList.Add(new Question("¿Qué jugador tiene más apariciones en la Premier League?", "Giggs"));
        questionsList.Add(new Question("¿Quién ganó el Balón de Oro en 1999?", "Rivaldo"));
        questionsList.Add(new Question("¿Quién es el máximo goleador de la historia de la Bundesliga?", "Muller"));
        questionsList.Add(new Question("¿Qué selección africana ha participado en más Mundiales?", "Nigeria"));
        questionsList.Add(new Question("¿Qué jugador es conocido como \"El Príncipe\"?", "Icardi"));
        questionsList.Add(new Question("¿Quién es el máximo goleador en la historia de la Premier League?", "Shearer"));
        questionsList.Add(new Question("¿Qué jugador holandés es conocido como \"El Tulipán de Oro\"?", "Cruyff"));
        questionsList.Add(new Question("¿Qué equipo inglés ganó la Champions League en 2012?", "Chelsea"));
        questionsList.Add(new Question("¿Quien es el rey del Chelsea?", "Drogba"));
        questionsList.Add(new Question("¿Qué equipo argentino ganó la Copa Libertadores en 2007?", "Boca"));
        questionsList.Add(new Question("¿Qué equipo francés es conocido como \"Les Parisiens\"?", "PSG"));
        questionsList.Add(new Question("¿Qué equipo ganó la Copa Libertadores en 1996?", "River"));
        questionsList.Add(new Question("¿Qué equipo inglés es conocido como \"The Blues\"?", "Chelsea"));
        questionsList.Add(new Question("¿Qué número de camiseta usaba Drogba en Chelsea?", "Once"));
        questionsList.Add(new Question("¿Qué trofeo ganó Hazard con el Chelsea en 2013?", "Europa"));
        questionsList.Add(new Question("¿Qué apodo es comúnmente asociado a Edgar Davids?", "Pitbull"));
        questionsList.Add(new Question("¿Qué número de camiseta solía usar Davids?", "Ocho"));
        questionsList.Add(new Question("¿Qué año fue fundado el Atlético Bucaramanga?", "1949"));
        questionsList.Add(new Question("¿Qué hinchada es conocida por apoyar al Atlético Bucaramanga?", "Fls"));
        questionsList.Add(new Question("¿Qué apodo es conocido para Samuel Eto'o?", "Leon"));
        questionsList.Add(new Question("¿Cuántas veces ganó la Champions League Eto'o?", "Tres"));
        questionsList.Add(
            new Question("¿Qué año ganó Agüero su primer título de la Premier League con el Manchester City?", "2012"));
        questionsList.Add(new Question(
            "¿Qué jugador argentino es famoso por su gol en la última jornada de la Premier League 2011-12?",
            "Aguero"));
        questionsList.Add(new Question(
            "¿En qué equipo jugó James Rodríguez en la Premier League durante la temporada 2020-2021?", "Everton"));
        questionsList.Add(new Question(
            "¿Qué jugador brasileño fue famoso por su paso en el PSG y el Barcelona en la década de 2010?", "Neymar"));
        questionsList.Add(new Question(
            "¿Qué defensa alemán jugó en el Bayern Múnich y es conocido por su fortaleza y habilidades aéreas?",
            "Hummels"));
        questionsList.Add(new Question(
            "¿Qué mediocampista belga es famoso por su paso por el Chelsea y el Manchester City?", "Bruyne"));
        questionsList.Add(
            new Question("¿Qué delantero sueco es conocido por su paso por el PSG y el Manchester United?", "Ibrahim"));
        questionsList.Add(new Question("¿Qué futbolista francés jugó en el Atlético de Madrid y el Manchester United?",
            "Pogba"));
        questionsList.Add(new Question(
            "¿Qué delantero polaco es conocido por su paso por el Borussia Dortmund y el Bayern Múnich?", "Lewand"));
        questionsList.Add(new Question("¿Qué defensa central portugués jugó en el Benfica y el Manchester City?",
            "Dias"));
        questionsList.Add(
            new Question("¿Qué defensa italiano es conocido por su largo paso por la Juventus y el Milan?", "Bonucci"));
        questionsList.Add(
            new Question("¿Qué delantero argentino jugó en el Atlético de Madrid y el Sevilla?", "Correa"));
        questionsList.Add(new Question("¿Qué mediocampista alemán jugó en el Borussia Dortmund y el Real Madrid?",
            "Ozil"));
        questionsList.Add(new Question("¿Qué defensa francés es conocido por su paso por el Chelsea y el Real Madrid?",
            "Varane"));
        questionsList.Add(new Question("¿Qué delantero nigeriano es conocido por su paso por el Arsenal y el Chelsea?",
            "Kanu"));
        questionsList.Add(new Question("¿Qué delantero inglés es famoso por su paso por el Tottenham Hotspur?",
            "Kane"));
        questionsList.Add(
            new Question("¿Qué delantero belga es conocido por su paso por el Chelsea y el Inter de Milán?", "Lukaku"));
        questionsList.Add(new Question("¿Qué defensa portugués jugó en el Oporto y el Liverpool?", "Pepe"));
        questionsList.Add(new Question(
            "¿Qué defensa español es conocido por su paso en el Atlético de Madrid y el Barcelona?", "Godin"));
        questionsList.Add(new Question("¿Qué delantero brasileño es conocido por su paso en el Roma y el Milan?",
            "Kaka"));
        questionsList.Add(new Question("¿Qué defensa argentino ha jugado en el PSG y el Napoli?", "Funes"));
        questionsList.Add(new Question("¿Qué delantero brasileño jugó en el Real Madrid y el Milan en los años 2000?",
            "Ronaldo"));
        questionsList.Add(new Question(
            "¿Qué mediocampista argentino fue famoso por su paso por el Real Madrid y el Manchester United en los años 2000?",
            "Veron"));
        questionsList.Add(new Question(
            "¿Qué delantero español jugó en el Liverpool y el Atlético de Madrid en los años 2000?", "Torres"));
        questionsList.Add(new Question("¿Qué defensa español jugó en el Real Madrid y el Barcelona en los años 2000?",
            "Puyol"));
        questionsList.Add(new Question(
            "¿Qué mediocampista alemán jugó en el Bayern Múnich y el Real Madrid en los años 2000?", "Ballack"));
        questionsList.Add(new Question("¿Qué delantero uruguayo jugó en el Villarreal y el Liverpool en los años 2000?",
            "Forlan"));
        questionsList.Add(new Question(
            "¿Qué delantero uruguayo ganó la Bota de Oro en 2010 y es conocido por su paso en el Liverpool y el Atlético de Madrid?",
            "Suarez"));
        questionsList.Add(new Question("¿Qué selección africana llegó a la final de la Copa del Mundo en 1990?",
            "Camerun"));
        questionsList.Add(new Question("¿Qué equipo tiene como colores el amarillo y azul?", "Boca"));
        questionsList.Add(new Question("¿Qué jugador francés es conocido como \"El Mago\"?", "Zidane"));
        questionsList.Add(new Question("¿Qué país fue sede de la Copa Mundial en 2002?", "Corea"));
        questionsList.Add(new Question(
            "¿Qué apodo popular se usa para referirse a José Mourinho debido a su estilo y personalidad?", "Special"));
        questionsList.Add(new Question("¿En qué año José Mourinho ganó la UEFA Champions League con el Inter de Milán?",
            "2010"));
        questionsList.Add(new Question(
            "¿Qué equipo colombiano, conocido por su apodo \"Los Tiburones\", es uno de los clubes más exitosos de la región caribeña?",
            "Junior"));
        questionsList.Add(new Question(
            "¿Qué mediocampista inglés, conocido por su paso en el Manchester United, ganó 6 títulos de la Premier League?",
            "Scholes"));
        questionsList.Add(new Question(
            "¿Qué selección nacional ganó la Copa del Mundo en 2010 y está dirigida por Vicente del Bosque?",
            "España"));
        questionsList.Add(new Question(
            "¿Qué delantero inglés, conocido por su paso en el Manchester United y el Real Madrid, es famoso por su capacidad de anotación?",
            "Owen"));
        questionsList.Add(new Question(
            "¿Qué arquero italiano es conocido por su larga carrera en la Juventus y por ser uno de los mejores en su posición?",
            "Buffon"));
        questionsList.Add(new Question(
            "¿Qué arquero alemán, famoso por su paso por el Bayern Múnich y el Manchester City, es conocido por su habilidad con los pies?",
            "Neuer"));
        questionsList.Add(new Question(
            "¿En qué club británico Edwin van der Sar tuvo su primera gran oportunidad en la Premier League?",
            "Fulham"));
        questionsList.Add(new Question(
            "¿Qué lateral izquierdo brasileño es famoso por su potente tiro libre y su paso por el Real Madrid?",
            "Carlos"));
        questionsList.Add(new Question(
            "¿Qué delantero argentino jugó en el Manchester City y el Atlético de Madrid y es famoso por su capacidad de anotación?",
            "Aguero"));
        questionsList.Add(new Question(
            "¿Qué arquero argentino, famoso por su paso por el Racing Club y el Barcelona, es conocido por sus actuaciones en la selección?",
            "Ubaldo"));
        questionsList.Add(new Question(
            "¿Qué delantero argentino, famoso por su paso por el Villarreal y el Manchester City, es conocido por su capacidad de anotación?",
            "Tevez"));
        questionsList.Add(new Question(
            "¿Qué árbitro italiano es conocido por su distintivo calvo y sus decisiones firmes, y dirigió la final del Mundial 2002?",
            "Collina"));
        questionsList.Add(new Question(
            "¿Qué equipo francés, donde juega Ángel Di María desde 2015, es conocido por su dominancia en la Ligue 1?",
            "PSG"));
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