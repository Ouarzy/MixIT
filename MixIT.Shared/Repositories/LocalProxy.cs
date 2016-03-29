using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MixIT.Shared.Models;
using MixIT.Shared.Models.Queries;

namespace MixIT.Shared.Repositories
{
    public class LocalProxy : IProxy
    {
        public Task<ITalksQuery> LoadTalksAsync()
        {
            return Task.Run<ITalksQuery>(() => new TalksQuery(CreateFakeTalksQueries()));
        }

        public Task<ITalksQuery> LoadLightTalksAsync()
        {
            return Task.Run<ITalksQuery>(() => new TalksQuery(CreateFakeLightTalksQueries()));
        }

        private IEnumerable<ITalkQuery> CreateFakeTalksQueries()
        {
            yield return
                new TalkQuery(
                    new Talk(
                        "(fake) La recette du fier développeur.",
                        "Tu te sens frustré au travail? Prends les choses en mains, voici quelques ingrédients pour devenir un fier développeur.",
                        @"Tu as l'impression de ne jamais avoir le temps. De devoir être partout à la fois. A chaque fois que tu pars en vacances tu as l'impression que l'entreprise n'y survivra pas. Tu sais que tu es important pour cette entreprise, et pourtant tu te sens frustré.
Car au final, malgré tout tes efforts, malgré les litres de café, les nuits sans sommeil, le peu de loisirs que tu t'accordes, les clients ne sont pas vraiment satisfaits. Et pour cause: bien que tu fasses beaucoup de concessions, les bugs de ton produit compliquent la vie de tes clients.
Alors tu travail toujours dans l'urgence pour mieux les satisfaire, et pourtant ils sont de moins en moins satisfait. C'est un cercle vicieux.
Cette situation est très répandue, ce qui n'est pas une raison pour l'accepter. Cette situation je l'ai connu, et j'aimerais aujourd'hui te proposer les ingrédients qui ont transformé ce cercle vicieux en cercle vertueux dans mon cas.
Ce n'est certainement pas une recette miracle, juste des ingrédients que tu devras digérer et adapter pour en profiter.",
                             new List<Speaker>
                             {
                                 new Speaker("Emilien", "Pecoul", "http://www.gravatar.com/avatar/569a344428936ce3b601ee3c12d8a100.png")
                             },
                        "Salle Eisenberg",
                        LanguageEnum.fr,
                        Talk.MixItFirstDay,
                        TimeSpan.FromHours(8),
                        TimeSpan.FromHours(10)),
                    null);

            yield return
                 new TalkQuery(
                     new Talk(
                "(fake) Crafting Workshop",
                "Expérimenter les valeurs du software crafsmanship. Réaliser le site mobile du mix-IT en déploiement continu.",
                @"Envie de promouvoir les valeurs du software crafsmanship, mais votre patron ne vous laisse pas faire ? Alors venez développer le site mobile du mix-IT. Un atelier sera ouvert pendant 2 jours où vous pourrez venir contribuer en pair programming le temps que vous le souhaitez. Grâce au déploiement continu, vous pourrez avoir un feedback en temps réel avec les participants du mix-IT.
Le site sera sous la forme d’une Single Page Application avec un serveur node.js.
Vous êtes développeur mais vous ne connaissez pas bien JavaScript, alors c’est l’occasion de découvrir avec du Pair Programming.
Vous n’êtes pas développeur, vous pourrez également participer en donnant un feedback, des idées ou pourquoi pas un design.",
                             new List<Speaker>
                             {
                                 new Speaker("Florent", "Pellet", "http://www.gravatar.com/avatar/569a344428936ce3b601ee3c12d8a100.png")
                             },
            "Salle Eisenberg",
            LanguageEnum.fr,
            Talk.MixItFirstDay,
            TimeSpan.FromHours(8),
            TimeSpan.FromHours(8)),
                    null);

            yield return
                new TalkQuery(
                    new Talk(
                "(fake) Développement, Agilité, Innovation, DevOps, Lean Startup",
                "Nous faisons des métiers passionnants et d'une richesse incroyable. Nous sommes les acteurs du Web et des logiciels.",
                "blllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalala",
                             new List<Speaker>
                             {
                                 new Speaker("Zach", "Holman", "http://www.gravatar.com/avatar/569a344428936ce3b601ee3c12d8a100.png")
                            },
                "Salle Matthew",
                LanguageEnum.fr,
                Talk.MixItFirstDay,
                TimeSpan.FromHours(8),
                TimeSpan.FromHours(8)),
                    null);

            yield return
                 new TalkQuery(
                     new Talk(
                "(fake) Software architecture for developers ",
                "A talk for software developers that want to learn more about software architecture, technical leadership and the balance with agility",
                "blllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalala",
                             new List<Speaker>
                             {
                                new Speaker("Simon ", "Brown", "http://www.gravatar.com/avatar/569a344428936ce3b601ee3c12d8a100.png"),
                            },
                "Salle Matthew",
                LanguageEnum.en,
                Talk.MixItFirstDay,
                TimeSpan.FromHours(8),
                TimeSpan.FromHours(8)),
                    null);

            yield return
                 new TalkQuery(
                     new Talk(
                "(fake) Create mobile application with PhoneGap ",
                "I'll explain my development strategy, why I chose PhoneGap, and what I've learnt along the way.",
                "blllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalala",
                new List<Speaker>
                {
                    new Speaker("Pamela ", "Fox", "http://www.gravatar.com/avatar/569a344428936ce3b601ee3c12d8a100.png"),
                },
                "Salle Colocinte",
                LanguageEnum.en,
                Talk.MixItFirstDay,
                TimeSpan.FromHours(8),
                TimeSpan.FromHours(8)),
                    null);

            yield return new TalkQuery(
                new Talk(
           "(fake) Software architecture for developers ",
           "A talk for software developers that want to learn more about software architecture, technical leadership and the balance with agility",
           "blllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalala",
            new List<Speaker> {
                    new Speaker("Simon ", "Brown", "http://www.gravatar.com/avatar/569a344428936ce3b601ee3c12d8a100.png"),
            },
           "Salle Matthew",
           LanguageEnum.en,
           Talk.MixItSecondDay,
           TimeSpan.FromHours(8),
           TimeSpan.FromHours(8)),
           null);

            yield return new TalkQuery(
                new Talk(
                "(fake) Create mobile application with PhoneGap ",
                "I'll explain my development strategy, why I chose PhoneGap, and what I've learnt along the way.",
                "blllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalalablllllllllllllllllllalalala",
                new List<Speaker>
                {
                    new Speaker("Pamela ", "Fox", "http://www.gravatar.com/avatar/569a344428936ce3b601ee3c12d8a100.png"),
                },
                "Salle Colocinte",
                LanguageEnum.en,
                Talk.MixItSecondDay,
                TimeSpan.FromHours(8),
                TimeSpan.FromHours(8)),
                    null);
        }

        private IEnumerable<ITalkQuery> CreateFakeLightTalksQueries()
        {
            yield return
                new TalkQuery(
                new Talk(
            "(fake) Votre API n'est pas RESTful.",
            "5 minutes pour expliquer comment transformer une API HTTP en API RESTful, challenge accepté !",
            @"",
            new List<Speaker>
                {
            new Speaker("David", "Larlet", "http://www.gravatar.com/avatar/569a344428936ce3b601ee3c12d8a100.png"),
                },
            "Salle Eisenberg",
            LanguageEnum.fr,
            Talk.MixItFirstDay,
            TimeSpan.FromHours(8),
            TimeSpan.FromHours(10)),
            null);

            yield return
                new TalkQuery(
                new Talk(
                "(fake)  en finir avec les méthodes agiles",
                "Depuis bien longtemps, j’avoue avoir une petite irritation lorsque j’entends parler de « méthodes agiles ». Je vais vous expliquer pourquoi.",
                @"Depuis bien longtemps, j’avoue avoir une petite irritation lorsque j’entends parler de « méthodes agiles ». Je vais vous expliquer pourquoi. Je vous rassure tout de suite, mon intention n’est pas de dire que l’agilité ne sert à rien ! Bien au contraire, je reste, malgré ce titre peut-être un peu provocateur, un fervent supporter de l’adoption des principes qui guident l’agilité pour permettre d’atteindre le but ultime : produire de la valeur. Non, là n’est pas mon intention. Ce qui m’irrite, donc, c’est d’entendre ces deux mots si plein de sens ensemble : Comment peut-on parler de « méthode » lorsque l’on parle d’agilité ? Il faut dépasser le cadre des méthodes, et comprendre le sens des choses.",
            new List<Speaker>
                {
                    new Speaker("Jérôme", "Avoustin", "http://www.gravatar.com/avatar/569a344428936ce3b601ee3c12d8a100.png"),
            },
            "Salle Eisenberg",
            LanguageEnum.fr,
            Talk.MixItFirstDay,
            TimeSpan.FromHours(8),
            TimeSpan.FromHours(8)),
            null);
        }
    }
}
