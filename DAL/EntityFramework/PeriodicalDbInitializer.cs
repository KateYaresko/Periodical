using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;


namespace DAL.EntityFramework
{
    public class PeriodicalDbInitializer : DropCreateDatabaseAlways<PeriodicalContext> //DropCreateDatabaseIfModelChanges<PeriodicalContext>
    {
        protected override void Seed(PeriodicalContext db)
        {
            var roleAdmin = new Role { Name = "Admin" };
            var roleEditor = new Role { Name = "Editor" };
            var roleUser = new Role { Name = "User" };
            var roles = new List<Role> { roleAdmin, roleEditor, roleUser };
            roles.ForEach(s => db.Roles.Add(s));
            db.SaveChanges();

            var userAdmin = new User { FirstName = "Kateryna", LastName = "Yaresko", Email="admin@gmail.com", Password="123456", Role = roleAdmin, Cash = 10000,  IsBlocked = false };
            var userEditor = new User { FirstName = "Iurii", LastName = "Khmelenko", Email = "editor@gmail.com", Password = "123456", Cash = 5000, IsBlocked = false };
            var userDefault = new User { FirstName = "Petr", LastName = "Vasichkin", Email = "user@gmail.com", Password = "123456", Cash = 1000, IsBlocked = false };
            var users = new List<User> { userAdmin, userEditor, userDefault };
            users.ForEach(s => db.Users.Add(s));
            db.SaveChanges();

            var NatureCategory = new Category { Name = "Nature", IconName = "leaf", BackgroundImgName = "nature-editions.jpg", HomeImgName = "monkey-home.jpg" };
            var FashionCategory = new Category { Name = "Fashion", IconName = "sunglasses", BackgroundImgName = "fashion-editions.jpg", HomeImgName = "fashion-home.jpg" };
            var SportCategory = new Category { Name = "Sport", IconName = "knight", BackgroundImgName = "sport-editions.jpg", HomeImgName = "swimming-home.jpg" };
            var NewsCategory = new Category { Name = "News", IconName = "globe", BackgroundImgName = "news-editions.jpg", HomeImgName = "news-home.jpg" };
            var ScienceCategory = new Category { Name = "Science", IconName = "education", BackgroundImgName = "science-editions.jpg", HomeImgName = "science-home.jpg" };
            var ArtCategory = new Category { Name = "Art", IconName = "picture", BackgroundImgName = "art-editions.jpg", HomeImgName = "art-home.jpg" };
            //var ProgrammingCategory = new Category { Name = "Programming", IconName = "cd", BackgroundImgName = "programming-editions.jpg", HomeImgName = "art-home.jpg" };
            var categories = new List<Category> { NatureCategory, FashionCategory, SportCategory, NewsCategory, ScienceCategory, ArtCategory};
            categories.ForEach(s => db.Categories.Add(s));
            db.SaveChanges();

            var NatureFauneEdition = new Edition { Name = "Nature & Faune", Price = 29.99, Category = NatureCategory };
            var FutureNatureEdition = new Edition { Name = "The Future of Nature", Price = 31.98, Category = NatureCategory };
            var NaturesDayEdition = new Edition { Name = "Nature's Day", Price = 27.99, Category = NatureCategory };

            var BazaarEdition = new Edition { Name = "Bazaar", Price = 39.99, Category = FashionCategory };
            var VogueEdition = new Edition { Name = "Vogue", Price = 37.95, Category = FashionCategory };
            var CosmopolitanEdition = new Edition { Name = "Cosmopolitan", Price = 31.98, Category = FashionCategory };

            var SportFitnessEdition = new Edition { Name = "Sport & Fitness", Price = 25.99, Category = SportCategory };
            var SportLifeEdition = new Edition { Name = "Sport Life", Price = 27.95, Category = SportCategory };
            var SportGirlsEdition = new Edition { Name = "Sport Girls", Price = 33.98, Category = SportCategory };

            var NewsWeekEdition = new Edition { Name = "Newsweek", Price = 20.89, Category = NewsCategory };
            var WeeklyNewsEdition = new Edition { Name = "Weekly News", Price = 21.95, Category = NewsCategory };
            var TimeEdition = new Edition { Name = "Time", Price = 23.98, Category = NewsCategory };

            var PopularScienceEdition = new Edition { Name = "Popular Science", Price = 28.89, Category = ScienceCategory };
            var DiscoverEdition = new Edition { Name = "Discover", Price = 25.95, Category = ScienceCategory };
            var CosmosEdition = new Edition { Name = "Cosmos", Price = 23.87, Category = ScienceCategory };

            var DirectArtEdition = new Edition { Name = "Direct Art", Price = 31.89, Category = ArtCategory };
            var ArtWorldEdition = new Edition { Name = "Art World", Price = 30.95, Category = ArtCategory };
            var ArtHiveEdition = new Edition { Name = "Art Hive", Price = 29.98, Category = ArtCategory };

            //var SmartDeveloperEdition = new Edition { Name = "Smart Developer", Price = 45.99, Category = ProgrammingCategory };
            //var MyLinuxEdition = new Edition { Name = "MyLinux", Price = 46.95, Category = ProgrammingCategory };
            //var GamedeveloperEdition = new Edition { Name = "Game Developer", Price = 49.98, Category = ProgrammingCategory };

            var editions = new List<Edition> { NatureFauneEdition, FutureNatureEdition, NaturesDayEdition, 
                                               BazaarEdition, VogueEdition, CosmopolitanEdition,
                                               SportFitnessEdition, SportLifeEdition, SportGirlsEdition,
                                               NewsWeekEdition, WeeklyNewsEdition, TimeEdition,
                                               PopularScienceEdition, DiscoverEdition, CosmosEdition,
                                               DirectArtEdition, ArtWorldEdition, ArtHiveEdition};
                                               //SmartDeveloperEdition, MyLinuxEdition, GamedeveloperEdition};
            editions.ForEach(s => db.Editions.Add(s));
            db.SaveChanges();

            var ChameleonArticle = new Article
            {
                Title = "Chameleons Use Built-In Crystals to Change Color",
                Text = @"Color-changing panther chameleons are among the most disco-ready lizards, courtesy of tiny, built-in crystals that rapidly create multicolored hues.
                        Embedded in the panther chameleon’s skin are not one, but two layers of crystal-containing cells, scientists at Switzerland’s University of Geneva report Tuesday in Nature Communications. Stretching or relaxing the cells helps the animals rapidly change color by changing the color of reflected light. (See more amazing chameleon pictures.)
                        Only adult male panther chameleons (Furcifer pardalis) have a fully developed upper layer of the cells, called iridophores, which they use to put on multihued shows for mating. When the crystals are close together, such as when the animal is relaxed, they reflect blue light. When they are combined with yellow pigments in the chameleon skin, the animal appears green. Stretching the cells and moving the crystals farther apart produces colors ranging from yellow to red.
                        All of the chameleons have a deeper layer of iridophores that reflects a broader spectrum of light, particularly the near-infrared, which is invisible but is close to the wavelengths felt as heat.
                        Scientists speculate that these deeper crystal-containing cells help the cold-blooded animals regulate their body temperature, while the more superficial layer of color-changing cells is involved in camouflage and flashy mating displays. (See photos of insect masters of camouflage.)",
                ImgName = "chameleon-article.jpg",
                DateTime = new DateTime(2014, 1, 18),
                Edition = NatureFauneEdition
            };
            var ButterflyArticle = new Article
            {
                Title = "Why Do Butterflies Have Such Vibrant Colors and Patterns?",
                Text = @"Ask a social butterfly where she got that great dress, and she'll say, 'This old thing?' and then tell you its entire history.
                        Ask an actual butterfly about its colorful attire, and things get a lot more complicated.
                        Our Weird Animal Question of the Week comes to us from National Geographic's own Angie McPherson, a volunteer at the Smithsonian Butterfly Garden in Washington, D.C.'s National Museum of Natural History. She asked, 'Why does the paper kite butterfly create a gold chrysalis?' (See 'New Golden Bat Adds to Animals With the Midas Touch.')
                        The paper kite butterfly, native to Asia, is light yellow or off-white with an elaborate pattern of swooping black lines and dots. But its chrysalis—a hard case that protects the caterpillar during its final transformation into a butterfly—is a shiny, golden hue.
                        It's unknown why the chrysalis itself is gold, but its shininess helps camouflage the developing butterfly, says Katy Prudic, a biologist at Oregon State University in Corvallis.
                        In particular, the sheen is 'disruptive' to potential predators—it makes the chrysalis 'hard to detect in a complicated background,' Prudic says. A hungry bird may even think it looks like a drop of water.",
                ImgName = "butterfly-article.jpg",
                DateTime = new DateTime(2014, 11, 25),
                Edition = NatureFauneEdition
            };
            var FishArticle = new Article
            {
                Title = "How This Cave-Dwelling Fish Lost Its Eyes to Evolution",
                Text = @"Few animals have ignored the warning “use it or lose it” as spectacularly as the Mexican blind cavefish (Astyanax mexicanus), which no longer has eyes.
                        Now scientists may have solved the riddle of why the fish lost their eyes in the dark.
                        With food so scarce in caves, the animals have to save their energy—and being sightless gives them a major boost, according to a team from Sweden's Lund University. (Read more about this peculiar fish on our freshwater blog.)
                        The researchers cracked the puzzle by looking at members of the same fish species that live aboveground, in rivers of Texas and Mexico, and which have perfect vision.
                        For the study, the team acquired captive cavefish and measured the energy cost of their sight. They did this by calculating the oxygen consumption of their eyes and vision-related parts of their brain.
                        The results, published September 11 in the journal Science Advances, showed that for young, developing fish, the energy cost of sight is 15 percent greater than if they were blind.",
                ImgName = "fish-article.jpg",
                DateTime = new DateTime(2014, 11, 25),
                Edition = NatureFauneEdition
            };
            var DreamArticle = new Article
            {
                Title = "Do Animals Dream?",
                Text = @"It’s uncertain whether animals dream, but “it seems very likely,” Hugo Spiers, an experimental psychologist at University College London, says via email.
                        Spiers and colleagues have found that when lab rats are shown food and then go to sleep, certain cells in their brains seemed to map out how to get to the food, according to a study published in June in the journal eLife.
                        You might say they 'dreamed' their path to a reward.
                        In people, dreaming occurs during rapid-eye movement, or REM sleep, which most mammals also experience.
                        So 'it is reasonable to suppose that animals have something like what we call dreams,' says Patrick McNamara, director of the Evolutionary Neurobehavior Laboratory at Boston University.
                        McNamara notes that in 1959, French neuroscientist Michel Jouvet and his team altered cat brains to disable the mechanism that inhibits movement during REM sleep. (Take National Geographic magazine's sleep quiz.)
                        The sleeping cats raised their heads, suggesting they were watching unseen objects; arched their backs; and appeared to stalk prey and get in fights.",
                ImgName = "dream-article.jpg",
                DateTime = new DateTime(2015, 2, 28),
                Edition = NatureFauneEdition
            };
            var NoseArticle = new Article
            {
                Title = "Do Animals Blow Their Noses?",
                Text = @"They might not reach for a hanky, but some animals—including primates and dogs—have their own devices for clearing nasal passages.
                        Why does a gorilla have such big nostrils? Well, have you seen the size of those fingers?
                        That’s the perfect joke for this Saturday’s Weird Animal Question of the Week, which comes from National Geographic's own Deputy Research Director Brad Scriber. He asked: “Do any other animals blow their noses?”
                        They don’t use tissues, but some animals do clear their noses on purpose—as opposed to waiting for a sneeze.
                        'We see the apes blow their noses all the time'—either one nostril at a time or both simultaneously, Tracy Fenn, supervisor of mammals at the Jacksonville Zoo and Gardens in Florida, says via email.
                        Often gorillas opt to just use their fingers and taste test the results, she says—just as in the opening joke she passed along to us.
                        Genteel bonobos have have a special method of helping babies breathe better.
                        “I’ve seen mother bonobos using their mouths to suck the snot out of a congested infant’s nose,” Fenn says.
                        Because moms.",
                ImgName = "nose-article.jpg",
                DateTime = new DateTime(2015, 4, 5),
                Edition = NatureFauneEdition
            };

            var SunsetArticle = new Article
            {
                Title = "How Do Some Animals Make Their Own Sunscreen?",
                Text = @"Fish, hippopotamuses, and other animals produce chemicals that protect them from the sun's rays.
                        A recent study in the journal eLife found that some fish, birds, amphibians, and reptiles have the genes to produce gadusol, a compound that can act as a sunscreen.
                        'Gadusol absorbs UV radiation, particularly UVB [ultraviolet B], and dissipates it as heat,' study leader Taifo Mahmud, a professor of medicinal chemistry at Oregon State University, says via email.
                        The gadusol produced by zebrafish, a highly studied lab species, may even help scientists create a better sunscreen for people. (Also see ''Do Sunscreens' Tiny Particles Harm Ocean Life in Big Ways?')
                        By transferring the zebrafish genes into yeast in the lab, researchers were able to test gadusol’s activity as a sunscreen and show that it can be produced commercially.
                        So, can I just rub a zebrafish on my face next time I forget my sunscreen?
                        A bit impractical, says Mahmud, but cod and sea urchin eggs—popular sushi ingredients—can contain the radiation-absorbing chemical.
                        So 'you may have consumed gadusol without knowing it,' he says.
                        That doesn’t mean it will act as a sunscreen in you, however—so for now, follow experts' advice for sun protection.",
                ImgName = "hipo-article.jpg",
                DateTime = new DateTime(2015, 5, 5),
                Edition = FutureNatureEdition
            };
            var DangerArticle = new Article
            {
                Title = "Has Yosemite’s Iconic Half Dome Become Too Dangerous to Climb?",
                Text = @"After a month of rockfalls, climbers are reminded that rock solid sometimes isn’t solid enough.
                        Over the July 4th weekend, Greg Stock lay awake at night, listening to thunderstorms tear through Yosemite Valley, California.
                        “It seemed like rockfall weather,” says Stock, Yosemite’s official park geologist and a rockfall specialist. “I think if it were a calm and quiet night, I would’ve heard it. But it was not a calm and quiet night.”
                        According to Stock, what he would’ve heard was a slab of rock avalanching off the Regular Northwest Face, a 2,200-foot (671-meter) climbing route on Half Dome, Yosemite’s iconic granite peak. It likely happened on July 3, but it wasn’t reported until two days later, when climbers Andrew Brodhead and Scott Sinner attempted to scale the route, but turned back upon realizing that a huge swath of rock had fallen, leaving behind a section of sheer, vertical terrain that appeared unclimbable.
                        The slab of rock that fell was shaped like an isosceles triangle: 200 feet tall and 100 feet wide (60 by 30 meters). It’s estimated to have been between 5 and 15 feet (1.5 and 4.5 meters) thick, and it likely weighed about five million pounds (2.2 million kilograms).
                        To a seasoned climber on the route, the disappearance of this much rock would be as shocking as a New Yorker casually walking down 5th Avenue and seeing the Flatiron building had vanished.
                        “I don’t know how many climbers have climbed over this feature,” says Stock. “Thousands? Tens of thousands? Now it’s gone.”
                        If a climbing route is like a vertical highway, then this rockfall would be as problematic as the collapse of a major bridge. Either a new bridge needs to be built, or a new way around the water needs to be discovered. Some climbers spent the month of July trying to find that path. Yet despite a handful of attempts, so far the Regular Northwest Face has not seen a complete ascent. Most climbers, however, have simply chosen to steer clear of Half Dome due to the reports of continued, albeit smaller, rockfall activity. Many wonder if the north face of Half Dome has just become too risky.",
                ImgName = "danger-article.jpg",
                DateTime = new DateTime(2015, 7, 5),
                Edition = FutureNatureEdition
            };
            var SeaArticle = new Article
            {
                Title = "Just How Much Could the Sea Rise from Burning Fossil Fuels? A Lot.",
                Text = @"New research predicts a stunning meltoff of the Antarctic Ice Sheet if all of the world's accessible fossil fuel is burned.
                        New York City would be swallowed by the ocean. Tokyo and Shanghai, too, would vanish.
                        Sea levels stand to rise by a staggering 164 feet (50 meters) or more if the world goes for broke on fossil fuels, burning all its attainable resources. That's because the Antarctic Ice Sheet would melt entirely from the warming caused by those emissions, concludes a study published Friday in Science Advances. The researchers say their paper offers the first long-term look at how carbon dioxide emissions from oil, coal, and natural gas would affect the entire ice sheet.
                        'If we don't stop dumping our waste CO2 into the sky, land that is now home to more than billion people will one day be underwater,' says study co-author Ken Caldeira, senior scientist at Stanford University's Carnegie Institution for Science. (See an interactive map of the world if all the ice melted.)
                        There's a bright side, sort of: The full melt would take about 10,000 years. However, at least 100 feet of the swell, as modeled in the paper from scientists in Germany, California, and the United Kingdom, would occur in this millennium, at a rate of more than an inch per year—a harrowing prospect, given that many coastal areas are already seeing land loss and flooding from much more modest sea level increases.",
                ImgName = "sea-article.jpg",
                DateTime = new DateTime(2015, 7, 8),
                Edition = FutureNatureEdition
            };
            var ClimateArticle = new Article
            {
                Title = "How U.S. Climate Plan Can Follow China and Europe — Or Not",
                Text = @"The U.S. will likely expand “cap and trade” to curb emissions. Several countries are trying this, but their mixed results may offer lessons in what not to do.
                        The United States aims to lead other countries with its climate plan. Yet one of its key but lesser-known tools, carbon trading, has already taken root across the globe.
                        In the last decade, 17 “cap and trade” systems—covering 35 countries and a dozen states or provinces—have sprung up to curb global warming. They cap total emissions of heating-trapping carbon dioxide but allow emitters to trade pollution allowances.
                        Such a trading system gets new life in President Barack Obama’s Clean Power Plan—in somewhat backdoor fashion. Five years ago, Obama failed to get a controversial cap-and-trade bill passed in Congress. Now, states can opt to launch a market or join existing ones in California and the Northeast.
                        “States can enter into markets the EPA can manage and keep track of,” Gina McCarthy, administrator of the Environmental Protection Agency, said Tuesday at a Washington, D.C. forum. Indeed, under the plan, trading becomes the default federal option for states that don’t submit plans for cutting emissions.
                        “It’s a ready-made plan” that focuses on emissions trading, McCarthy said, adding it will offer states flexibility and could spur clean energy innovation. “The U.S. can grab some leadership here.”
                        The plan’s final 1,560-page rule, unveiled last week, is much more explicit about carbon trading that the proposed version last year. “It makes a 180-degree turn and embraces trading as the way to go,” says Tom Lawler, Washington, D.C. representative of the nonprofit International Emissions Trading Association, which promotes cap-and-trade.
                        The rule even says: “It is reasonable to anticipate that a virtually nationwide emissions trading market for compliance will emerge.” (Learn about five of the plan’s common myths.)",
                ImgName = "climate-article.jpg",
                DateTime = new DateTime(2015, 8, 1),
                Edition = FutureNatureEdition
            };
            var TheoryArticle = new Article
            {
                Title = "12 Theories of How We Became Human, and Why They’re All Wrong",
                Text = @"Killers? Hippies? Toolmakers? Chefs? Scientists have trouble agreeing on the essence of humanity—and when and how we acquired it.
                        1. We Make Tools: “It is in making tools that man is unique,” anthropologist Kenneth Oakley wrote in a 1944 article. Apes use found objects as tools, he explained, “but the shaping of sticks and stones to particular uses was the first recognizably human activity.” In the early 1960s, Louis Leakey attributed the dawn of toolmaking, and thus of humanity, to a species named Homo habilis (“Handy Man”), which lived in East Africa around 2.8 million years ago. But as Jane Goodall and other researchers have since shown, chimps also shape sticks for particular uses—stripping them of their leaves, for instance, to “fish” for underground insects. Even crows, which lack hands, are pretty handy.
                        2. We’re Killers: According to anthropologist Raymond Dart, our predecessors differed from living apes in being confirmed killers—carnivorous creatures that 'seized living quarries by violence, battered them to death, tore apart their broken bodies, dismembered them limb from limb, slaking their ravenous thirst with the hot blood of victims and greedily devouring livid writhing flesh.” It may read like pulp fiction now, but after the horrific carnage of the Second World War, Dart’s 1953 article outlining his “killer ape” theory struck a chord.
                        3. We Share Food: In the 1960s, the killer ape gave way to the hippie ape. Anthropologist Glynn Isaac unearthed evidence of animal carcasses that had been purposefully moved from the sites of their deaths to locations where, presumably, the meat could be shared with the whole commune. As Isaac saw it, food sharing led to the need to share information about where food could be found—and thus to the development of language and other distinctively human social behaviors.
                        4. We Swim in the Nude: A little later in the age of Aquarius, Elaine Morgan, a TV documentary writer, claimed that humans are so different from other primates because our ancestors evolved in a different environment—near and in the water. Shedding body hair made them faster swimmers, while standing upright enabled them to wade. The “aquatic ape” hypothesis is widely dismissed by the scientific community. But, in 2013, David Attenborough endorsed it.
                        5. We Throw Stuff: Archaeologist Reid Ferring believes our ancestors began to man up when they developed the ability to hurl stones at high velocities. At Dmanisi, a 1.8- million-year-old hominin site in the former Soviet republic of Georgia, Ferring found evidence that Homo erectus invented public stonings to drive predators away from their kills. “The Dmanisi people were small,” says Ferring.“This place was filled with big cats. So how did hominins survive? How did they make it all the way from Africa? Rock throwing offers part of the answer.” Stoning animals also socialized us, he argues, because it required a group effort to be successful.
                        6. We Hunt: Hunting did much more than inspire cooperation, anthropologists Sherwood Washburn and C. S. Lancaster argued in a 1968 paper: “In a very real sense our intellect, interests, emotions and basic social life—all are evolutionary products of the success of the hunting adaptation.” Our larger brains, for instance, developed out of the need to store more information about where and when to find game. Hunting also allegedly led to a division of labor between the sexes, with women doing the foraging. Which raises the question: Why do women have big brains too?
                        7. We Trade Food for Sex: More specifically, monogamous sex. The crucial turning point in human evolution, according to a theory published in 1981 by C. Owen Lovejoy, was the emergence of monogamy six million years ago. Until then, brutish alpha males who drove off rival suitors had the most sex. Monogamous females, however, favored males who were most adept at providing food and sticking around to help raise junior. Our ancestors began walking upright, according to Lovejoy, because it freed up their hands and allowed them to carry home more groceries.
                        8. We Eat (Cooked) Meat: Big brains are hungry—gray matter requires 20 times more energy than muscle does. They could never have evolved on a vegetarian diet, some researchers claim; instead, our brains grew only once we started eating meat, a food source rich in protein and fat, around two to three million years ago. And according to anthropologist Richard Wrangham, once our ancestors invented cooking—a uniquely human behavior that makes food easier to digest—they wasted less energy chewing or pounding meat and so had even more energy available for their brains. Eventually those brains grew large enough to make the conscious decision to become vegan.
                        9. We Eat (Cooked) Carbs: Or maybe our bigger brains were made possible by carb-loading, according to a recent paper. Once our ancestors had invented cooking, tubers and other starchy plants became an excellent source of brain food, more readily available than meat. An enzyme in our saliva called amylase helps break down carbohydrates into the glucose the brain needs. Evolutionary geneticist Mark G. Thomas of University College London notes that our DNA contains multiple copies of the gene for amylase, suggesting that it—and tubers—helped fuel the explosive growth of the human brain.
                        10. We Walk on Two Feet: Did the crucial turning point in human evolution occur when our ancestors descended from the trees and started walking upright? Proponents of the “savanna hypothesis” say climate change drove that adaptation. As Africa became drier around three million years ago, the forests shrank and savannas came to dominate the landscape. That favored primates who could stand up and see above the tall grasses to watch for predators, and who could travel more efficiently across the open landscape, where food and water sources were far apart. One problem for this hypothesis is the 2009 discovery of Ardipithecus ramidus, a hominid that lived 4.4 million years ago in what’s now Ethiopia. That region was damp and wooded then—yet “Ardi” could walk on two legs.
                        11. We Adapt: Richard Potts, director of the Smithsonian's Human Origins Program, suggests that human evolution was influenced by multiple changes in climate rather than a single trend. The emergence of the Homo lineage nearly three million years ago, he says, coincided with drastic fluctuations between wet and dry climates. Natural selection favored primates that could cope with constant, unpredictable change, Potts argues: Adaptability itself is the defining characteristic of humans.
                        12. We Unite and Conquer: Anthropologist Curtis Marean offers a vision of human origins well suited to our globalized age: We are the ultimate invasive species. After tens of thousands of years confined to a single continent, our ancestors colonized the globe. How did they accomplish this feat? The key, Marean says, was a genetic predisposition to cooperate—born not from altruism but from conflict. Primate groups that cooperated gained a competitive edge over rival groups, and their genes survived. “The joining of this unique proclivity to our ancestors’ advanced cognitive abilities enabled them to nimbly adapt to new environments,” Marean writes. “It also fostered innovation, giving rise to a game-changing technology: advanced projectile weapons.”",
                ImgName = "theory-article.jpg",
                DateTime = new DateTime(2015, 8, 11),
                Edition = FutureNatureEdition
            };

            var LaboratoryArticle = new Article
            {
                Title = "New High-Tech Laboratory in Kazakhstan to Fight Plague Outbreaks",
                Text = @"$102 million biosecurity facility will open in 2015.
                        In a dusty suburb near Almaty, Kazakhstan, where the Soviet-era buildings still hint at a different time, a slice of high-tech modernity has arrived—in the form of a $102 million biosecurity laboratory.
                        The Central Reference Laboratory (CRL) will open in 2015 and offer high-security lab space for scientists to study dangerous diseases and provide early warning of potential outbreaks. (Read about the global war on disease.)
                        The facility, funded by the United States Defense Threat Reduction Agency (DTRA) and the Nunn-Lugar Cooperative Threat Reduction Program, will have the additional benefit of giving stable employment to scientists who might otherwise be tempted to sell their high-level and potentially destructive knowledge to hostile groups, said Lt. Col. Charles Carlton, director of the DTRA offices in Kazakhstan.
                        The facility will also be a secure place to archive existing disease strains. The threat of theft is real: In 2002, for example, authorities arrested a man who entered a biodefense facility near Almaty, apparently intending to steal the pathogens inside, according to a paper from the United States Institute of Peace.
                        The CRL will join an existing network of DTRA bio-threat reduction facilities—such as the Richard G. Lugar Center for Public Health Research that opened in Tbilisi, Georgia, in 2011—that are designed to stop diseases, such as plague, from spreading globally.
                        Yersinia pestis, the bacterium that causes bubonic, pneumonic, and septicemic plagues, is spread by rats and fleas. The disease emerged only about ten thousand years ago but has claimed hundreds of millions of lives during its brief time on Earth, including roughly one-third of the entire population of Europe in the 14th century, when the infection was called the Black Death. (See National Geographic plague photos.)
                        But it's not just a thing of the past: Plague is now regarded as a 're-emerging disease,' with several thousand cases, including a current outbreak in northern Kyrgyzstan, occurring all over the world each year. Plague symptoms include sudden fever, chills, and extreme weakness.
                        Bubonic plague also produces swollen, painful lymph nodes, called buboes. Septicemic plague causes portions of skin to turn black and die. When caught early and treated with antibiotics, naturally occurring forms of bubonic and septicemic plague are not usually fatal. But pneumonic plague, the most severe, is harder to treat and is the only form of the disease that can spread from person to person.
                        Earlier this year, a study published in Infection, Genetics, and Evolution concluded that there's still a serious risk of plague originating in developing countries. (Related: 'Spawn of Medieval 'Black Death' Bug Still Roam the Earth.')
                        That's why the new lab is so important: In the event of an outbreak of plague, anthrax, cholera, or other diseases, scientists would access a reference index of various disease strains for immediate identification, diagnosis, and treatment, said Carlton.
                        'The hope is that this will become a regional center for scientists from throughout Central Asia and the Caucuses to exchange information and conduct training and research,' he said, adding that the CRL will act as a hub for a large network of Kazakh diagnostic laboratories. (See pictures of Astana, Kazakhstan's new capital.)
                        'That free exchange of information between scientists and researchers is really the biggest benefit.'",
                ImgName = "laboratory-article.jpg",
                DateTime = new DateTime(2015, 8, 15),
                Edition = NaturesDayEdition
            };
            var BatArticle = new Article
            {
                Title = "Bats and Sloths Don't Get Dizzy Hanging Upside Down — Here's Why",
                Text = @"Being tiny and moving slowly are key for animals who live on the flip side.
                        There’s a reason gravity boots never caught on: Being upside down can get pretty uncomfortable after a while.
                        Noting the headaches that come with being inverted, National Geographic writer and editor Jane J. Lee asked Saturday’s Weird Animal Question of the Week: 'Why don’t bats, and other animals that hang upside down, suffer the same fate?'
                        The average adult human carries about 2 gallons (7.5 liters) of blood, according to the American Red Cross. That’s a lot of liquid suddenly rushing to your head if you were to hang upside down—hence the discomfort.
                        By comparison, bats are lightweights. The tiniest bat in the world, Kitti’s hog-nosed bat, also known as the bumblebee bat, weighs in at 0.07 ounces. Even the two largest known bat species, Australia’s black flying fox and the Philippines' golden-crowned flying fox, weigh only up to 2.5 pounds (1.1 kilograms). (Watch a video of black flying foxes in action.)
                        As a result, bats don't 'weigh enough for gravity to affect their blood flow,' says Rob Mies, director of the Michigan-based Organization for Bat Conservation via email.
                        There's another benefit to hanging upside down—it's takes less effort. Specialized tendons in bat feet enable them to hang while being perfectly relaxed. If they were sitting right side up, they'd have to contract a muscle—and thus expend energy—to let go and begin flying.",
                ImgName = "bat-article.jpg",
                DateTime = new DateTime(2015, 8, 20),
                Edition = NaturesDayEdition
            };
            var WindArticle = new Article
            {
                Title = "Wind Industry Plans Serious Changes to Protect Bats",
                Text = @"The move to ramp down turbines during the fall migration season is 'a big deal,' says one scientist.
                        Migratory bats, for some reason, have a lethal attraction to wind turbines. Now, they may get help via 'feathering.'
                        New industry guidelines, to be announced Thursday, aim to save tens of thousands of bats each year by idling turbines at low wind speeds during peak bat migration season. They could reduce by a third the number of bats killed at wind farms.
                        Seventeen members of the American Wind Energy Association, a trade group, have agreed voluntarily to begin idling, or feathering, turbines in the next year or two. Together, the companies produce nearly 90 percent of the wind power generated in the United States.",
                ImgName = "wind-article.jpg",
                DateTime = new DateTime(2015, 8, 29),
                Edition = NaturesDayEdition
            };
            var PlagueArticle = new Article
            {
                Title = "Plague Warning Closes Campground in Yosemite",
                Text = @"Risk of deadly disease is low, but squirrel deaths in park raise alarm.
                        Update: The California Department of Public Health has announced that a second visitor to Yosemite National Park was infected with “presumptive positive” case of plague. The hiker, from the state of Georgia, is hospitalized and being treated with antibiotics. 
                        There are going to be a few unhappy campers in Yosemite National Park this week.
                        Park officials shuttered the Tuolumne Meadows campground in Yosemite on Monday after finding the carcasses of two squirrels that died of plague. Last month, a child who had stayed at Crane Flat Campground in Yosemite was infected, the first case in the park since 1959 and the first in California since 2006.
                        So far, eight people have contracted plague across the United States this year, including two people who have died in Colorado this summer, according to the U.S. Centers for Disease Control. The cases involving plague, which typically is spread by fleas that have bitten infected rodents or by the infected animals themselves, are a reminder of the persistent presence of a disease that has caused pandemics throughout history, and that wiped out an estimated 50 million people in Asia, Africa, and Europe in the 14th century.
                        Experts are hesitant to say there’s been a spike in plague activity this year. In recent decades, the U.S. has seen an average of seven plague cases annually, but the numbers vary significantly year to year. In 2010 there were only two cases of plague nationwide, while in 2014 there were 10.
                        This year’s count of eight cases so far “is not extraordinary by any means,” says Kenneth Gage, Chief of Entomology and Ecology Activity with the CDC. “But some of the circumstances have been somewhat unusual,” he says, including the number of fatalities in Colorado and the human case in Yosemite.",
                ImgName = "plague-article.jpg",
                DateTime = new DateTime(2015, 8, 29),
                Edition = NaturesDayEdition
            };
            var WhalesArticle = new Article
            {
                Title = "Sperm Whales' Language Reveals Hints of Culture",
                Text = @"These deep-diving whales off the Galápagos have their own dialects, a sign that they have a culture.
                        New ways to grab dinner, the trick to using a tool, and learning the local dialect. These are behaviors that animals pick up from each other. Killer whales, chimpanzees, and birds seem to have a cultural component to their lives. Now a new study suggests that sperm whales should be added to that list.
                        The ocean around the Galápagos Islands hosts thousands of female sperm whales and their calves that have organized into clans with their own dialects. (Mature males congregate in colder waters near the poles.) How these clans form has been something of a mystery until now.
                        A study published Tuesday in the journal Nature Communications suggests that culture—behaviors shared by group members—keeps these sperm whale clans together. Specifically, these deep-diving whales have a distinct series of clicks called codas they use to communicate during social interactions.
                        Sperm whales with similar behaviors spend time together, and they pick up vocalizations from each other. Scientists call this social learning. Whales that 'speak the same language' stick together, giving rise to the clans that researchers have observed for more than 30 years.",
                ImgName = "whales-article.jpg",
                DateTime = new DateTime(2015, 9, 1),
                Edition = NaturesDayEdition
            };

            var articles = new List<Article> { ChameleonArticle, ButterflyArticle, FishArticle, DreamArticle, NoseArticle,
                                               SunsetArticle, DangerArticle, SeaArticle, ClimateArticle, TheoryArticle,
                                               LaboratoryArticle, BatArticle, WindArticle, PlagueArticle, WhalesArticle};
            articles.ForEach(s => db.Articles.Add(s));
            db.SaveChanges();
        }
    }
}
