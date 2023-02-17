using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GermoBank.Models;

public partial class GermoBankUtnContext : DbContext
{
    public GermoBankUtnContext()
    {
    }

    public GermoBankUtnContext(DbContextOptions<GermoBankUtnContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccecionesTb> AccecionesTbs { get; set; }

    public virtual DbSet<AntecedentesTb> AntecedentesTbs { get; set; }

    public virtual DbSet<CantonesTb> CantonesTbs { get; set; }

    public virtual DbSet<ClimasTb> ClimasTbs { get; set; }

    public virtual DbSet<ColectoresTb> ColectoresTbs { get; set; }

    public virtual DbSet<DireccionesTb> DireccionesTbs { get; set; }

    public virtual DbSet<EspeciesTb> EspeciesTbs { get; set; }

    public virtual DbSet<EstadosGermoplasmasTb> EstadosGermoplasmasTbs { get; set; }

    public virtual DbSet<FamiliasTb> FamiliasTbs { get; set; }

    public virtual DbSet<FormasGeograficasTb> FormasGeograficasTbs { get; set; }

    public virtual DbSet<GenerosTb> GenerosTbs { get; set; }

    public virtual DbSet<IntitutosColectoresTb> IntitutosColectoresTbs { get; set; }

    public virtual DbSet<LocalidadesTb> LocalidadesTbs { get; set; }

    public virtual DbSet<MetodosMuestreosTb> MetodosMuestreosTbs { get; set; }

    public virtual DbSet<PaisesTb> PaisesTbs { get; set; }

    public virtual DbSet<ParroquiasTb> ParroquiasTbs { get; set; }

    public virtual DbSet<PlagasEnfermedadesTb> PlagasEnfermedadesTbs { get; set; }

    public virtual DbSet<PracticasCulturalesTb> PracticasCulturalesTbs { get; set; }

    public virtual DbSet<PropiedadesTb> PropiedadesTbs { get; set; }

    public virtual DbSet<PropietariosTb> PropietariosTbs { get; set; }

    public virtual DbSet<ProvinciasTb> ProvinciasTbs { get; set; }

    public virtual DbSet<SubespeciesTb> SubespeciesTbs { get; set; }

    public virtual DbSet<SuelosTb> SuelosTbs { get; set; }

    public virtual DbSet<TexturasSuelosTb> TexturasSuelosTbs { get; set; }

    public virtual DbSet<UsosTb> UsosTbs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=GermoBank_UTN;User Id=postgres;Password=root;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccecionesTb>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("acceciones_tb");

            entity.HasIndex(e => e.IdAntecedenteFk, "antecedente_accesion_fk");

            entity.HasIndex(e => e.IdColectorFk, "colector_accesion_fk");

            entity.HasIndex(e => e.IdEstadoGermoplasmaFk, "estado_accesion_fk");

            entity.HasIndex(e => e.IdAccesionPk, "id_accesion_pk").IsUnique();

            entity.HasIndex(e => e.IdMetodoMuestraFk, "metodo_accesion_fk");

            entity.HasIndex(e => e.IdPropiedadFk, "propiedad_accesion_fk");

            entity.HasIndex(e => e.IdSubespecieFk, "subespecie_accesion_fk");

            entity.Property(e => e.AislamientoPoblacional).HasColumnName("aislamiento_poblacional");
            entity.Property(e => e.CultivosCernanos).HasColumnName("cultivos_cernanos");
            entity.Property(e => e.EjemplarHerbario).HasColumnName("ejemplar_herbario");
            entity.Property(e => e.FechaRecoleccionAccesion).HasColumnName("fecha_recoleccion_accesion");
            entity.Property(e => e.Fotografia).HasColumnName("fotografia");
            entity.Property(e => e.IdAccesionPk)
                .HasMaxLength(50)
                .HasColumnName("id_accesion_pk");
            entity.Property(e => e.IdAntecedenteFk).HasColumnName("id_antecedente_fk");
            entity.Property(e => e.IdColectorFk)
                .HasMaxLength(10)
                .HasColumnName("id_colector_fk");
            entity.Property(e => e.IdEstadoGermoplasmaFk).HasColumnName("id_estado_germoplasma_fk");
            entity.Property(e => e.IdMetodoMuestraFk).HasColumnName("id_metodo_muestra_fk");
            entity.Property(e => e.IdPropiedadFk).HasColumnName("id_propiedad_fk");
            entity.Property(e => e.IdSubespecieFk).HasColumnName("id_subespecie_fk");
            entity.Property(e => e.NombreLocalAccesion)
                .HasMaxLength(50)
                .HasColumnName("nombre_local_accesion");

            entity.HasOne(d => d.IdAntecedenteFkNavigation).WithMany()
                .HasForeignKey(d => d.IdAntecedenteFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("antecedente_accesion_fk");

            entity.HasOne(d => d.IdColectorFkNavigation).WithMany()
                .HasForeignKey(d => d.IdColectorFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("colector_accesion_fk");

            entity.HasOne(d => d.IdEstadoGermoplasmaFkNavigation).WithMany()
                .HasForeignKey(d => d.IdEstadoGermoplasmaFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("estado_accesion_fk");

            entity.HasOne(d => d.IdMetodoMuestraFkNavigation).WithMany()
                .HasForeignKey(d => d.IdMetodoMuestraFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("metodo_accesion_fk");

            entity.HasOne(d => d.IdPropiedadFkNavigation).WithMany()
                .HasForeignKey(d => d.IdPropiedadFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("propiedad_accesion_fk");

            entity.HasOne(d => d.IdSubespecieFkNavigation).WithMany()
                .HasForeignKey(d => d.IdSubespecieFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("subespecie_accesion_fk");
        });

        modelBuilder.Entity<AntecedentesTb>(entity =>
        {
            entity.HasKey(e => e.IdAntecedentePk).HasName("antecedentes_tb_pkey");

            entity.ToTable("antecedentes_tb");

            entity.HasIndex(e => e.IdAntecedentePk, "id_antecedente_pk").IsUnique();

            entity.HasIndex(e => e.IdPlagaEnfermedadFk, "plaga_antecedente_fk");

            entity.HasIndex(e => e.IdPracticaCulturalFk, "practica_antecedente_fk");

            entity.HasIndex(e => e.IdUsoFk, "uso_antecedente_fk");

            entity.Property(e => e.IdAntecedentePk).HasColumnName("id_antecedente_pk");
            entity.Property(e => e.FechaCosecha).HasColumnName("fecha_cosecha");
            entity.Property(e => e.FechaFloracion).HasColumnName("fecha_floracion");
            entity.Property(e => e.FechaFructuacion).HasColumnName("fecha_fructuacion");
            entity.Property(e => e.FechaSiembra).HasColumnName("fecha_siembra");
            entity.Property(e => e.IdPlagaEnfermedadFk).HasColumnName("id_plaga_enfermedad_fk");
            entity.Property(e => e.IdPracticaCulturalFk).HasColumnName("id_practica_cultural_fk");
            entity.Property(e => e.IdUsoFk).HasColumnName("id_uso_fk");
            entity.Property(e => e.ObservacionAntecedente)
                .HasMaxLength(200)
                .HasColumnName("observacion_antecedente");

            entity.HasOne(d => d.IdPlagaEnfermedadFkNavigation).WithMany(p => p.AntecedentesTbs)
                .HasForeignKey(d => d.IdPlagaEnfermedadFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("plaga_antecedente_fk");

            entity.HasOne(d => d.IdPracticaCulturalFkNavigation).WithMany(p => p.AntecedentesTbs)
                .HasForeignKey(d => d.IdPracticaCulturalFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("practica_antecedente_fk");

            entity.HasOne(d => d.IdUsoFkNavigation).WithMany(p => p.AntecedentesTbs)
                .HasForeignKey(d => d.IdUsoFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("uso_antecedente_fk");
        });

        modelBuilder.Entity<CantonesTb>(entity =>
        {
            entity.HasKey(e => e.IdCantonPk).HasName("cantones_tb_pkey");

            entity.ToTable("cantones_tb");

            entity.HasIndex(e => e.IdCantonPk, "id_canton_pk").IsUnique();

            entity.HasIndex(e => e.IdProvinciaFk, "id_provincia_canton_fk");

            entity.Property(e => e.IdCantonPk)
                .HasMaxLength(10)
                .HasColumnName("id_canton_pk");
            entity.Property(e => e.IdProvinciaFk)
                .HasMaxLength(10)
                .HasColumnName("id_provincia_fk");
            entity.Property(e => e.NombreCanton)
                .HasMaxLength(50)
                .HasColumnName("nombre_canton");

            entity.HasOne(d => d.IdProvinciaFkNavigation).WithMany(p => p.CantonesTbs)
                .HasForeignKey(d => d.IdProvinciaFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("provincia_canton_fk");
        });

        modelBuilder.Entity<ClimasTb>(entity =>
        {
            entity.HasKey(e => e.IdClimaPk).HasName("climas_tb_pkey");

            entity.ToTable("climas_tb");

            entity.HasIndex(e => e.IdClimaPk, "id_clima_pk").IsUnique();

            entity.Property(e => e.IdClimaPk).HasColumnName("id_clima_pk");
            entity.Property(e => e.HumedadClima)
                .HasPrecision(2, 2)
                .HasColumnName("humedad_clima");
            entity.Property(e => e.Luz)
                .HasMaxLength(50)
                .HasColumnName("luz");
            entity.Property(e => e.TemperaturaClima)
                .HasPrecision(2, 2)
                .HasColumnName("temperatura_clima");
        });

        modelBuilder.Entity<ColectoresTb>(entity =>
        {
            entity.HasKey(e => e.IdColectorPk).HasName("colectores_tb_pkey");

            entity.ToTable("colectores_tb");

            entity.HasIndex(e => e.IdColectorPk, "id_colector_pk").IsUnique();

            entity.HasIndex(e => e.IdDireccionFk, "id_direccion_colector_fk");

            entity.HasIndex(e => e.IdInstitutoFk, "id_instituto_colector_fk");

            entity.Property(e => e.IdColectorPk)
                .HasMaxLength(10)
                .HasColumnName("id_colector_pk");
            entity.Property(e => e.ContaseniaColector)
                .HasMaxLength(50)
                .HasColumnName("contasenia_colector");
            entity.Property(e => e.EmailColector)
                .HasMaxLength(50)
                .HasColumnName("email_colector");
            entity.Property(e => e.IdDireccionFk).HasColumnName("id_direccion_fk");
            entity.Property(e => e.IdInstitutoFk)
                .HasMaxLength(10)
                .HasColumnName("id_instituto_fk");
            entity.Property(e => e.PrimerApellidoColector)
                .HasMaxLength(50)
                .HasColumnName("primer_apellido_colector");
            entity.Property(e => e.PrimerNombreColector)
                .HasMaxLength(50)
                .HasColumnName("primer_nombre_colector");
            entity.Property(e => e.SegundoApellidoColector)
                .HasMaxLength(50)
                .HasColumnName("segundo_apellido_colector");
            entity.Property(e => e.SegundoNombreColector)
                .HasMaxLength(50)
                .HasColumnName("segundo_nombre_colector");
            entity.Property(e => e.TelefonoColecto)
                .HasMaxLength(15)
                .HasColumnName("telefono_colecto");

            entity.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.ColectoresTbs)
                .HasForeignKey(d => d.IdDireccionFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("direccion_instituto_fk");

            entity.HasOne(d => d.IdInstitutoFkNavigation).WithMany(p => p.ColectoresTbs)
                .HasForeignKey(d => d.IdInstitutoFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("instituto_colector_fk");
        });

        modelBuilder.Entity<DireccionesTb>(entity =>
        {
            entity.HasKey(e => e.IdDireccionPk).HasName("direcciones_tb_pkey");

            entity.ToTable("direcciones_tb");

            entity.HasIndex(e => e.IdDireccionPk, "id_direccion_pk").IsUnique();

            entity.HasIndex(e => e.IdParroquiaFk, "id_parroquia_direccion_fk");

            entity.Property(e => e.IdDireccionPk).HasColumnName("id_direccion_pk");
            entity.Property(e => e.CallePrincipal)
                .HasMaxLength(100)
                .HasColumnName("calle_principal");
            entity.Property(e => e.CalleSecundaria)
                .HasMaxLength(100)
                .HasColumnName("calle_secundaria");
            entity.Property(e => e.IdParroquiaFk)
                .HasMaxLength(10)
                .HasColumnName("id_parroquia_fk");
            entity.Property(e => e.ReferenciaDirecion)
                .HasMaxLength(200)
                .HasColumnName("referencia_direcion");

            entity.HasOne(d => d.IdParroquiaFkNavigation).WithMany(p => p.DireccionesTbs)
                .HasForeignKey(d => d.IdParroquiaFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("parroquia_direccion_fk");
        });

        modelBuilder.Entity<EspeciesTb>(entity =>
        {
            entity.HasKey(e => e.IdEspeciePk).HasName("especies_tb_pkey");

            entity.ToTable("especies_tb");

            entity.HasIndex(e => e.IdGeneroFk, "genero_especie_fk");

            entity.HasIndex(e => e.IdEspeciePk, "id_especie_pk").IsUnique();

            entity.Property(e => e.IdEspeciePk).HasColumnName("id_especie_pk");
            entity.Property(e => e.IdGeneroFk).HasColumnName("id_genero_fk");
            entity.Property(e => e.NombreEspecie)
                .HasMaxLength(50)
                .HasColumnName("nombre_especie");

            entity.HasOne(d => d.IdGeneroFkNavigation).WithMany(p => p.EspeciesTbs)
                .HasForeignKey(d => d.IdGeneroFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("genero_especie_fk");
        });

        modelBuilder.Entity<EstadosGermoplasmasTb>(entity =>
        {
            entity.HasKey(e => e.IdEstadoGermoplasmaPk).HasName("estados_germoplasmas_tb_pkey");

            entity.ToTable("estados_germoplasmas_tb");

            entity.HasIndex(e => e.IdEstadoGermoplasmaPk, "id_estado_germoplasma_pk").IsUnique();

            entity.Property(e => e.IdEstadoGermoplasmaPk).HasColumnName("id_estado_germoplasma_pk");
            entity.Property(e => e.NombreEstadoGermoplasma)
                .HasMaxLength(50)
                .HasColumnName("nombre_estado_germoplasma");
        });

        modelBuilder.Entity<FamiliasTb>(entity =>
        {
            entity.HasKey(e => e.IdFamiliaPk).HasName("familias_tb_pkey");

            entity.ToTable("familias_tb");

            entity.HasIndex(e => e.IdFamiliaPk, "id_familia_pk").IsUnique();

            entity.Property(e => e.IdFamiliaPk).HasColumnName("id_familia_pk");
            entity.Property(e => e.NombreFamilia)
                .HasMaxLength(50)
                .HasColumnName("nombre_familia");
        });

        modelBuilder.Entity<FormasGeograficasTb>(entity =>
        {
            entity.HasKey(e => e.IdFormaGeograficaPk).HasName("formas_geograficas_tb_pkey");

            entity.ToTable("formas_geograficas_tb");

            entity.HasIndex(e => e.IdFormaGeograficaPk, "id_forma_geografica_pk").IsUnique();

            entity.Property(e => e.IdFormaGeograficaPk).HasColumnName("id_forma_geografica_pk");
            entity.Property(e => e.NombreFormaGeografica)
                .HasMaxLength(50)
                .HasColumnName("nombre_forma_geografica");
        });

        modelBuilder.Entity<GenerosTb>(entity =>
        {
            entity.HasKey(e => e.IdGeneroPk).HasName("generos_tb_pkey");

            entity.ToTable("generos_tb");

            entity.HasIndex(e => e.IdFamiliaFk, "famialia_genero_fk");

            entity.HasIndex(e => e.IdGeneroPk, "id_genero_pk").IsUnique();

            entity.Property(e => e.IdGeneroPk).HasColumnName("id_genero_pk");
            entity.Property(e => e.IdFamiliaFk).HasColumnName("id_familia_fk");
            entity.Property(e => e.NombreGenero)
                .HasMaxLength(50)
                .HasColumnName("nombre_genero");

            entity.HasOne(d => d.IdFamiliaFkNavigation).WithMany(p => p.GenerosTbs)
                .HasForeignKey(d => d.IdFamiliaFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("clase_genero_fk");
        });

        modelBuilder.Entity<IntitutosColectoresTb>(entity =>
        {
            entity.HasKey(e => e.IdInstitutoPk).HasName("intitutos_colectores_tb_pkey");

            entity.ToTable("intitutos_colectores_tb");

            entity.HasIndex(e => e.IdDireccionFk, "id_direccion_instituto_fk");

            entity.HasIndex(e => e.IdInstitutoPk, "id_instituto_pk").IsUnique();

            entity.Property(e => e.IdInstitutoPk)
                .HasMaxLength(10)
                .HasColumnName("id_instituto_pk");
            entity.Property(e => e.DetalleInstituto)
                .HasMaxLength(100)
                .HasColumnName("detalle_instituto");
            entity.Property(e => e.IdDireccionFk).HasColumnName("id_direccion_fk");
            entity.Property(e => e.NombreInstituto)
                .HasMaxLength(50)
                .HasColumnName("nombre_instituto");

            entity.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.IntitutosColectoresTbs)
                .HasForeignKey(d => d.IdDireccionFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("direccion_instituto_fk");
        });

        modelBuilder.Entity<LocalidadesTb>(entity =>
        {
            entity.HasKey(e => e.IdLocalidadPk).HasName("localidades_tb_pkey");

            entity.ToTable("localidades_tb");

            entity.HasIndex(e => e.IdClimaFk, "clima_localidad_fk");

            entity.HasIndex(e => e.IdDireccionFk, "direccion_localidad_fk");

            entity.HasIndex(e => e.IdFormaGeograficaFk, "forma_localidad_fk");

            entity.HasIndex(e => e.IdLocalidadPk, "id_localidad_pk").IsUnique();

            entity.Property(e => e.IdLocalidadPk).HasColumnName("id_localidad_pk");
            entity.Property(e => e.AltitudPropiedad)
                .HasMaxLength(50)
                .HasColumnName("altitud_propiedad");
            entity.Property(e => e.IdClimaFk).HasColumnName("id_clima_fk");
            entity.Property(e => e.IdDireccionFk).HasColumnName("id_direccion_fk");
            entity.Property(e => e.IdFormaGeograficaFk).HasColumnName("id_forma_geografica_fk");
            entity.Property(e => e.LatitudPropiedad)
                .HasMaxLength(50)
                .HasColumnName("latitud_propiedad");
            entity.Property(e => e.LongitudPropiedad)
                .HasMaxLength(50)
                .HasColumnName("longitud_propiedad");

            entity.HasOne(d => d.IdClimaFkNavigation).WithMany(p => p.LocalidadesTbs)
                .HasForeignKey(d => d.IdClimaFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("clima_localidad_fk");

            entity.HasOne(d => d.IdDireccionFkNavigation).WithMany(p => p.LocalidadesTbs)
                .HasForeignKey(d => d.IdDireccionFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("direccion_localidad_fk");

            entity.HasOne(d => d.IdFormaGeograficaFkNavigation).WithMany(p => p.LocalidadesTbs)
                .HasForeignKey(d => d.IdFormaGeograficaFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("forma_localidad_fk");
        });

        modelBuilder.Entity<MetodosMuestreosTb>(entity =>
        {
            entity.HasKey(e => e.IdMetodoMuestraPk).HasName("metodos_muestreos_tb_pkey");

            entity.ToTable("metodos_muestreos_tb");

            entity.HasIndex(e => e.IdMetodoMuestraPk, "id_metodo_muestra_pk").IsUnique();

            entity.Property(e => e.IdMetodoMuestraPk).HasColumnName("id_metodo_muestra_pk");
            entity.Property(e => e.NombreMetodoMuestra)
                .HasMaxLength(100)
                .HasColumnName("nombre_metodo_muestra");
        });

        modelBuilder.Entity<PaisesTb>(entity =>
        {
            entity.HasKey(e => e.IdPaisPk).HasName("paises_tb_pkey");

            entity.ToTable("paises_tb");

            entity.HasIndex(e => e.IdPaisPk, "id_pais_pk").IsUnique();

            entity.Property(e => e.IdPaisPk)
                .HasMaxLength(10)
                .HasColumnName("id_pais_pk");
            entity.Property(e => e.NombrePais)
                .HasMaxLength(50)
                .HasColumnName("nombre_pais");
        });

        modelBuilder.Entity<ParroquiasTb>(entity =>
        {
            entity.HasKey(e => e.IdParroquiaPk).HasName("parroquias_tb_pkey");

            entity.ToTable("parroquias_tb");

            entity.HasIndex(e => e.IdCantonFk, "id_canton_parroquia_fk").IsUnique();

            entity.HasIndex(e => e.IdParroquiaPk, "id_parroquia_pk").IsUnique();

            entity.Property(e => e.IdParroquiaPk)
                .HasMaxLength(10)
                .HasColumnName("id_parroquia_pk");
            entity.Property(e => e.IdCantonFk)
                .HasMaxLength(10)
                .HasColumnName("id_canton_fk");
            entity.Property(e => e.NombreParroquia)
                .HasMaxLength(50)
                .HasColumnName("nombre_parroquia");

            entity.HasOne(d => d.IdCantonFkNavigation).WithOne(p => p.ParroquiasTb)
                .HasForeignKey<ParroquiasTb>(d => d.IdCantonFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("canton_parroquia_fk");
        });

        modelBuilder.Entity<PlagasEnfermedadesTb>(entity =>
        {
            entity.HasKey(e => e.IdPlagaEnfermedadPk).HasName("plagas_enfermedades_tb_pkey");

            entity.ToTable("plagas_enfermedades_tb");

            entity.HasIndex(e => e.IdPlagaEnfermedadPk, "id_plaga_enfermedad_pk").IsUnique();

            entity.Property(e => e.IdPlagaEnfermedadPk).HasColumnName("id_plaga_enfermedad_pk");
            entity.Property(e => e.NombrePlagaEnfermedad)
                .HasMaxLength(50)
                .HasColumnName("nombre_plaga_enfermedad");
        });

        modelBuilder.Entity<PracticasCulturalesTb>(entity =>
        {
            entity.HasKey(e => e.IdPracticaCulturalPk).HasName("practicas_culturales_tb_pkey");

            entity.ToTable("practicas_culturales_tb");

            entity.HasIndex(e => e.IdPracticaCulturalPk, "id_practica_cultural_pk").IsUnique();

            entity.Property(e => e.IdPracticaCulturalPk).HasColumnName("id_practica_cultural_pk");
            entity.Property(e => e.NombrePracticaCultural)
                .HasMaxLength(100)
                .HasColumnName("nombre_practica_cultural");
        });

        modelBuilder.Entity<PropiedadesTb>(entity =>
        {
            entity.HasKey(e => e.IdPropiedadPk).HasName("propiedades_tb_pkey");

            entity.ToTable("propiedades_tb");

            entity.HasIndex(e => e.IdPropiedadPk, "id_propiedad_pk").IsUnique();

            entity.HasIndex(e => e.IdLocalidadFk, "localidad_propiedad_fk");

            entity.HasIndex(e => e.IdPropietarioFk, "propietario_propietario_fk");

            entity.HasIndex(e => e.IdSueloFk, "suelo_propiedad_fk");

            entity.Property(e => e.IdPropiedadPk).HasColumnName("id_propiedad_pk");
            entity.Property(e => e.IdLocalidadFk).HasColumnName("id_localidad_fk");
            entity.Property(e => e.IdPropietarioFk)
                .HasMaxLength(15)
                .HasColumnName("id_propietario_fk");
            entity.Property(e => e.IdSueloFk).HasColumnName("id_suelo_fk");
            entity.Property(e => e.NombrePropiedad)
                .HasMaxLength(50)
                .HasColumnName("nombre_propiedad");

            entity.HasOne(d => d.IdLocalidadFkNavigation).WithMany(p => p.PropiedadesTbs)
                .HasForeignKey(d => d.IdLocalidadFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("localidad_propiedad_fk");

            entity.HasOne(d => d.IdPropietarioFkNavigation).WithMany(p => p.PropiedadesTbs)
                .HasForeignKey(d => d.IdPropietarioFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("propietario_propietario_fk");

            entity.HasOne(d => d.IdSueloFkNavigation).WithMany(p => p.PropiedadesTbs)
                .HasForeignKey(d => d.IdSueloFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("suelo_propiedad_fk");
        });

        modelBuilder.Entity<PropietariosTb>(entity =>
        {
            entity.HasKey(e => e.IdPropietarioPk).HasName("propietarios_tb_pkey");

            entity.ToTable("propietarios_tb");

            entity.HasIndex(e => e.IdPropietarioPk, "id_propietario_pk").IsUnique();

            entity.Property(e => e.IdPropietarioPk)
                .HasMaxLength(15)
                .HasColumnName("id_propietario_pk");
            entity.Property(e => e.ApellidoPropietario)
                .HasMaxLength(100)
                .HasColumnName("apellido_propietario");
            entity.Property(e => e.EmailPropietario)
                .HasMaxLength(50)
                .HasColumnName("email_propietario");
            entity.Property(e => e.NombrePropietario)
                .HasMaxLength(50)
                .HasColumnName("nombre_propietario");
            entity.Property(e => e.TelefonoPropietario)
                .HasMaxLength(100)
                .HasColumnName("telefono_propietario");
        });

        modelBuilder.Entity<ProvinciasTb>(entity =>
        {
            entity.HasKey(e => e.IdProvinciaPk).HasName("provincias_tb_pkey");

            entity.ToTable("provincias_tb");

            entity.HasIndex(e => e.IdPaisFk, "id_pais_provincia_fk");

            entity.HasIndex(e => e.IdProvinciaPk, "id_provincia_pk").IsUnique();

            entity.Property(e => e.IdProvinciaPk)
                .HasMaxLength(10)
                .HasColumnName("id_provincia_pk");
            entity.Property(e => e.IdPaisFk)
                .HasMaxLength(10)
                .HasColumnName("id_pais_fk");
            entity.Property(e => e.NombreProvincia)
                .HasMaxLength(50)
                .HasColumnName("nombre_provincia");

            entity.HasOne(d => d.IdPaisFkNavigation).WithMany(p => p.ProvinciasTbs)
                .HasForeignKey(d => d.IdPaisFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("pais_provincia_fk");
        });

        modelBuilder.Entity<SubespeciesTb>(entity =>
        {
            entity.HasKey(e => e.IdSubespeciePk).HasName("subespecies_tb_pkey");

            entity.ToTable("subespecies_tb");

            entity.HasIndex(e => e.IdEspecieFk, "especie_subespecie_fk");

            entity.HasIndex(e => e.IdSubespeciePk, "id_subespecie_pk").IsUnique();

            entity.Property(e => e.IdSubespeciePk).HasColumnName("id_subespecie_pk");
            entity.Property(e => e.IdEspecieFk).HasColumnName("id_especie_fk");
            entity.Property(e => e.NombreSubespecie)
                .HasMaxLength(50)
                .HasColumnName("nombre_subespecie");

            entity.HasOne(d => d.IdEspecieFkNavigation).WithMany(p => p.SubespeciesTbs)
                .HasForeignKey(d => d.IdEspecieFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("especie_subespecie_fk");
        });

        modelBuilder.Entity<SuelosTb>(entity =>
        {
            entity.HasKey(e => e.IdSueloPk).HasName("suelos_tb_pkey");

            entity.ToTable("suelos_tb");

            entity.HasIndex(e => e.IdSueloPk, "id_suelo_pk").IsUnique();

            entity.HasIndex(e => e.IdTexturaSueloFk, "textura_suelo_fk");

            entity.Property(e => e.IdSueloPk).HasColumnName("id_suelo_pk");
            entity.Property(e => e.ColorSuelo)
                .HasMaxLength(50)
                .HasColumnName("color_suelo");
            entity.Property(e => e.DrenajeSuelo).HasColumnName("drenaje_suelo");
            entity.Property(e => e.ErosionSuelo).HasColumnName("erosion_suelo");
            entity.Property(e => e.IdTexturaSueloFk).HasColumnName("id_textura_suelo_fk");
            entity.Property(e => e.PedregosidadSuelo).HasColumnName("pedregosidad_suelo");

            entity.HasOne(d => d.IdTexturaSueloFkNavigation).WithMany(p => p.SuelosTbs)
                .HasForeignKey(d => d.IdTexturaSueloFk)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("textura_suelo_fk");
        });

        modelBuilder.Entity<TexturasSuelosTb>(entity =>
        {
            entity.HasKey(e => e.IdTexturaSueloPk).HasName("texturas_suelos_tb_pkey");

            entity.ToTable("texturas_suelos_tb");

            entity.HasIndex(e => e.IdTexturaSueloPk, "id_textura_suelo_pk").IsUnique();

            entity.Property(e => e.IdTexturaSueloPk).HasColumnName("id_textura_suelo_pk");
            entity.Property(e => e.NombreTexturaSuelo)
                .HasMaxLength(50)
                .HasColumnName("nombre_textura_suelo");
        });

        modelBuilder.Entity<UsosTb>(entity =>
        {
            entity.HasKey(e => e.IdUsoPk).HasName("usos_tb_pkey");

            entity.ToTable("usos_tb");

            entity.HasIndex(e => e.IdUsoPk, "id_uso_pk").IsUnique();

            entity.Property(e => e.IdUsoPk).HasColumnName("id_uso_pk");
            entity.Property(e => e.NombreUso)
                .HasMaxLength(50)
                .HasColumnName("nombre_uso");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
