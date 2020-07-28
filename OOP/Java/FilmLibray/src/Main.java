import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class Main {

    public static void main(String[] args) {
        List<Film> firstFilmLibrary = new ArrayList<Film>();
        List<Film> secondFilmLibrary = new ArrayList<Film>();
        List<Film> thirdFilmLibrary = new ArrayList<Film>();

        //Filling the film libraries with films
        fillFirstLibrary(firstFilmLibrary);
        fillSecondLibrary(secondFilmLibrary);
        fillThirdLibrary(thirdFilmLibrary);

        //Printing all films with De Niro as a main character
        printDeNiroFilms(firstFilmLibrary, "First");
        printDeNiroFilms(secondFilmLibrary, "Second");
        printDeNiroFilms(thirdFilmLibrary, "Third");

        //Printing all films
        printAllFilms(firstFilmLibrary, "First");
        printAllFilms(secondFilmLibrary, "Second");
        printAllFilms(thirdFilmLibrary, "Third");

        //Printing the average taxes
        printAverageLicenseTaxes(firstFilmLibrary, secondFilmLibrary,  thirdFilmLibrary);
    }

    static void fillFirstLibrary(List<Film> filmList){
        filmList.add(new Film("Rambo - First Blood", "Sylvester Stallone" , 1982, 125000));
        filmList.add(new Film("The Terminator", "Arnold Schwarzenegger", 1984, 15000));
        filmList.add(new Film("The Raging Bull", "Robert De Niro", 1980, 175000));
        filmList.add(new Film("Night and the City", "Robert De Niro", 1992, 145000));
        filmList.add(new Film("Up in the Air", "George Clooney", 2009, 14000));
        filmList.add(new Film("The Godfather", "Marlon Brando", 1972 , 156000));
        filmList.add(new Film("The Fighter", "Mark Wahleberg",2010 , 179000));
        filmList.add(new Film("You Don't Know Jack", "Al Pacino",2010 , 100000));
        filmList.add(new Film("Sam's Song", "Robert De Niro", 1969, 110000));
        filmList.add(new Film("Hi, Mom!", "Robert De Niro", 1970, 140000));
    }

    static void fillSecondLibrary(List<Film> filmList){
        filmList.add(new Film("Guilty by Suspicion", "Robert De Niro", 1991, 250000));
        filmList.add(new Film("Universal Soldier", "Jean-Claude Van Damme", 1992, 245000));
        filmList.add(new Film("Crank", "Jason Statham", 2006, 176500));
        filmList.add(new Film("The Ghost Writer", "Ewan McGregor", 2010 , 100050));
        filmList.add(new Film("Inception", "Leonardo Di Caprio",2010 , 137000));
        filmList.add(new Film("Sound of Noise", "Bengt Braskered", 2010 , 235000));
        filmList.add(new Film("Michael Clayton", "George Clooney",2007 , 345000));
        filmList.add(new Film("The Wolverine", "Hugh Jackman", 2013 , 123000));
        filmList.add(new Film("The Intern", "Robert De Niro", 2015, 360000));
        filmList.add(new Film("Bang the Drum Slowly", "Robert De Niro", 1973, 300000));
        filmList.add(new Film("Mean Streets", "Robert De Niro", 1973, 300500));
    }

    static void fillThirdLibrary(List<Film> filmList){
        filmList.add(new Film("Die Hard", "Bruce Willis", 1988, 140050));
        filmList.add(new Film("The Expendables", "Sylvester Stallone", 2012 , 210000));
        filmList.add(new Film("The Pacific", "James Dale",2010 , 126000));
        filmList.add(new Film("The Book of Eli", "Denzel Washington", 2010, 145333));
        filmList.add(new Film("The Matrix", "Keanu Reeves", 1999 , 178555));
        filmList.add(new Film("Fight Club", "Brad Pitt",1999 , 148000));
        filmList.add(new Film("Gladiator", "Russel Crow",2000, 268000));
        filmList.add(new Film("The Italian Job", "Michael Caine", 1969, 222222));
        filmList.add(new Film("Jacknife", "Robert De Niro", 1989, 111111));
        filmList.add(new Film("The Fan", "Robert De Niro", 1996, 333333));
        filmList.add(new Film("1900", "Robert De Niro",1976, 320000));
        filmList.add(new Film("The Last Tycoon", "Robert De Niro",1976, 323232));
    }

    static void printDeNiroFilms(List<Film> films, String index){
        System.out.println("\n" + index + " film library with Robert De Niro in main role: ");
        List<Film> filtered = films.stream().filter(f -> f.getMainRole().contains("Robert De Niro")).collect(Collectors.toList());

        //Sorted by two criteria - Realease date reversed and license tax.
        filtered.sort(Comparator.comparingInt((Film f) -> f.getReleaseDate()).reversed().thenComparingInt(f -> f.getLicenseTax()));

        for (Film film: filtered) {
            System.out.println(film.getFilmName() + "; " + film.getMainRole() + "; " + film.getReleaseDate() + "; " + film.getLicenseTax());
        }
    }

    static void printAllFilms(List<Film> films, String index){
        System.out.println("\n" + index + " film library");

        films.sort(Comparator.comparing(f -> f.getFilmName()));

        for (Film film : films) {
            System.out.println(film.getFilmName() + "; " + film.getMainRole() + "; " + film.getReleaseDate() + "; " + film.getLicenseTax());
        }
    }

    static double averageLicenseTax(List<Film> films){
        int count = 0;
        double sum = 0;
        for (Film film : films) {
            if(film.getReleaseDate() == 2010){
                sum += film.getLicenseTax();
                count++;
            }
        }
        return Math.round((sum / count) * 100.0) / 100.0;

    }

    static void printAverageLicenseTaxes(List<Film> list1, List<Film> list2, List<Film> list3){
        double firstAv = averageLicenseTax(list1);
        double secondAv = averageLicenseTax(list2);
        double thirdAv = averageLicenseTax(list3);
        double max =  Math.max(Math.max(firstAv, secondAv), thirdAv);

        System.out.println("\nFIRST FILM LIBRARY: Avarage license tax for films in 2010: " + firstAv);
        System.out.println("SECOND FILM LIBRARY: Avarage license tax for films in 2010: " + secondAv);
        System.out.println("THIRD FILM LIBRARY: Avarage license tax for films in 2010: " + thirdAv);

        if(firstAv > secondAv && firstAv > thirdAv){
            System.out.println("The biggest avarage license tax is from the first film library: " + firstAv);
        }else if(secondAv > firstAv && secondAv > thirdAv){
            System.out.println("The biggest avarage license tax is from the second film library: " + secondAv);
        }else if(thirdAv > firstAv && thirdAv > secondAv){
            System.out.println("The biggest avarage license tax is from the third film library" + thirdAv);
        }else{
            System.out.println("The license taxes from all film libraries are equal");
        }
    }
}
