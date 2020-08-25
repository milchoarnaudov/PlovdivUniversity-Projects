public class Film {
    private String filmName;
    private String[] mainRoles;
    private String mainRole;
    private int releaseDate;
    private int licenseTax;

    public Film(String _filmName, String[] _mainRoles, int _releaseDate, int _licenseTax){
        this.filmName = _filmName;
        this.mainRoles = _mainRoles;
        this.releaseDate = _releaseDate;
        this.licenseTax = _licenseTax;
    }

    public Film(String _filmName, String _mainRole, int _releaseDate, int _licenseTax){
        this.filmName = _filmName;
        this.mainRole = _mainRole;
        this.releaseDate = _releaseDate;
        this.licenseTax = _licenseTax;
    }

    //Getters
    public String getMainRole() {
        return mainRole;
    }

    public String getFilmName() {
        return filmName;
    }

    public String[] getMainRoles() {
        return mainRoles;
    }

    public int getReleaseDate() {
        return releaseDate;
    }

    public int getLicenseTax() {
        return licenseTax;
    }


}
