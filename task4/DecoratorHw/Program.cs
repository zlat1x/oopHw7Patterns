using System;

namespace Decorator.Examples
{
    // "Component" – абстрактна ялинка
    abstract class Yalynka
    {
        public abstract void Show();
    }

    // "ConcreteComponent" – звичайна ялинка без декору
    class SimpleYalynka : Yalynka
    {
        public override void Show()
        {
            Console.WriteLine("Проста ялинка без прикрас.");
        }
    }

    // "Decorator" – базовий декоратор ялинки
    abstract class YalynkaDecorator : Yalynka
    {
        protected Yalynka yalynka;

        public void SetYalynka(Yalynka yalynka)
        {
            this.yalynka = yalynka;
        }

        public override void Show()
        {
            if (yalynka != null)
            {
                yalynka.Show();
            }
        }
    }

    // "ConcreteDecoratorA" – додає ялинкові прикраси 
    class OrnamentsDecorator : YalynkaDecorator
    {
        private string ornaments; 

        public override void Show()
        {
            base.Show();
            ornaments = "іграшки, кульки, зірка";
            Console.WriteLine("Прикраси: {0}", ornaments);
        }
    }

    // "ConcreteDecoratorB" – додає гірлянди
    class GarlandDecorator : YalynkaDecorator
    {
        public override void Show()
        {
            base.Show();
            LightUp();
        }

        private void LightUp()
        {
            Console.WriteLine("Ялинка світиться гірляндами!");
        }
    }

    class Program
    {
        static void Main()
        {
            Yalynka yalynka = new SimpleYalynka();

            OrnamentsDecorator withOrnaments = new OrnamentsDecorator();
            withOrnaments.SetYalynka(yalynka);

            GarlandDecorator fullYalynka = new GarlandDecorator();
            fullYalynka.SetYalynka(withOrnaments);

            Console.WriteLine("Ялинка з прикрасами та гірляндами:");
            fullYalynka.Show();

            Console.ReadKey();
        }
    }
}