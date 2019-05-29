-- phpMyAdmin SQL Dump
-- version 4.6.6deb4
-- https://www.phpmyadmin.net/
--
-- Client :  localhost:3306
-- Généré le :  Mer 29 Mai 2019 à 13:48
-- Version du serveur :  10.1.26-MariaDB-0+deb9u1
-- Version de PHP :  7.0.27-0+deb9u1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `ContactAPI`
--

-- --------------------------------------------------------

--
-- Structure de la table `Course`
--

CREATE TABLE `Course` (
  `id` int(11) NOT NULL,
  `depart_course` date NOT NULL,
  `fin_course` date NOT NULL,
  `lieu_course` varchar(500) NOT NULL,
  `nom_course` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Course`
--

INSERT INTO `Course` (`id`, `depart_course`, `fin_course`, `lieu_course`, `nom_course`) VALUES
(1, '2019-03-20', '2019-03-20', 'Bar-le-duc', 'courseBar');

-- --------------------------------------------------------

--
-- Structure de la table `Equipe`
--

CREATE TABLE `Equipe` (
  `id_equipe` int(11) UNSIGNED NOT NULL,
  `nom_equipe` varchar(50) DEFAULT NULL,
  `couleur_equipe` varchar(50) DEFAULT NULL,
  `idCourse` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Equipe`
--

INSERT INTO `Equipe` (`id_equipe`, `nom_equipe`, `couleur_equipe`, `idCourse`) VALUES
(1, 'equipe1', 'jaune', 0),
(2, 'equipe2', 'rouge', 0);

-- --------------------------------------------------------

--
-- Structure de la table `Localisation`
--

CREATE TABLE `Localisation` (
  `id_localisation` int(11) NOT NULL,
  `date_actuelle` date NOT NULL,
  `temps_reel` varchar(500) NOT NULL,
  `longitude` varchar(500) NOT NULL,
  `latitude` varchar(500) NOT NULL,
  `idParticipant` int(11) UNSIGNED NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Localisation`
--

INSERT INTO `Localisation` (`id_localisation`, `date_actuelle`, `temps_reel`, `longitude`, `latitude`, `idParticipant`) VALUES
(1, '2019-03-13', '', '12.32', '789.1', 1),
(2, '2019-03-13', '', '789.2', '25.3', 2),
(3, '2019-02-20', '', '123.2', '448.1', 2),
(4, '2019-03-14', '', '52.1', '123.3', 1),
(5, '2019-02-15', '', '789.2', '25.3', 3);

-- --------------------------------------------------------

--
-- Structure de la table `Participant`
--

CREATE TABLE `Participant` (
  `id` int(11) UNSIGNED NOT NULL,
  `nom` varchar(50) DEFAULT '0',
  `prenom` varchar(50) DEFAULT '0',
  `email` varchar(50) DEFAULT '0',
  `motDePasse` varchar(50) DEFAULT NULL,
  `numero` varchar(12) DEFAULT '0',
  `sexe` varchar(50) DEFAULT NULL,
  `idEquipe` int(11) UNSIGNED DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `Participant`
--

INSERT INTO `Participant` (`id`, `nom`, `prenom`, `email`, `motDePasse`, `numero`, `sexe`, `idEquipe`) VALUES
(1, 'Pozzi', 'Fabien', 'pozzi.fabien@outlook.com', 'poz55', '0678965463', 'M', 2),
(2, 'Machin', 'Truc', 'machin.truc@gmail.com', 'azerty', '0696874512', 'F', 1),
(3, 'Heles', 'Julien', 'julien.heles@gmail.com', '1234', '0329857485', 'M', 1),
(4, 'Macron', 'Emmanuel', 'macron.manu@wanadoo.fr', '789', '0754125632', 'M', 2);

--
-- Index pour les tables exportées
--

--
-- Index pour la table `Course`
--
ALTER TABLE `Course`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `Equipe`
--
ALTER TABLE `Equipe`
  ADD PRIMARY KEY (`id_equipe`);

--
-- Index pour la table `Localisation`
--
ALTER TABLE `Localisation`
  ADD PRIMARY KEY (`id_localisation`),
  ADD KEY `FKLocalisation` (`idParticipant`);

--
-- Index pour la table `Participant`
--
ALTER TABLE `Participant`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FKEquipe` (`idEquipe`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `Course`
--
ALTER TABLE `Course`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table `Equipe`
--
ALTER TABLE `Equipe`
  MODIFY `id_equipe` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT pour la table `Localisation`
--
ALTER TABLE `Localisation`
  MODIFY `id_localisation` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT pour la table `Participant`
--
ALTER TABLE `Participant`
  MODIFY `id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `Localisation`
--
ALTER TABLE `Localisation`
  ADD CONSTRAINT `FKLocalisation` FOREIGN KEY (`idParticipant`) REFERENCES `Participant` (`id`);

--
-- Contraintes pour la table `Participant`
--
ALTER TABLE `Participant`
  ADD CONSTRAINT `FKEquipe` FOREIGN KEY (`idEquipe`) REFERENCES `Equipe` (`id_equipe`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
