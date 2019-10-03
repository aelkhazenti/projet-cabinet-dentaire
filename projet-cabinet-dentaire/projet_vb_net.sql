-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le :  mar. 28 mai 2019 à 22:04
-- Version du serveur :  10.1.38-MariaDB
-- Version de PHP :  7.1.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `projet_vb.net`
--

-- --------------------------------------------------------

--
-- Structure de la table `cahier_med`
--

CREATE TABLE `cahier_med` (
  `ID_CM` int(11) NOT NULL,
  `maladi_CM` varchar(50) NOT NULL,
  `note_de_doc` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `cahier_med`
--

INSERT INTO `cahier_med` (`ID_CM`, `maladi_CM`, `note_de_doc`) VALUES
(1, 'dfgdgf', 'dfgdfgd'),
(2, 'asd', 'asd'),
(10, 'poiuy', 'has'),
(11, 'hdgs', 'auap'),
(12, 'qwe', 'asdf'),
(13, 'asas', 'asas'),
(14, 'asdty', 'wert'),
(16, 'fgfgfgf', 'mnmnmnmnmnm'),
(17, 'ghgf', 'uyuy'),
(18, 'qwerty', 'qwertyaz'),
(19, 'xxx', 'xxx'),
(20, 'asfsfdsf', 'asasd'),
(22, 'teest', 'teestt'),
(23, 'fv', 'dfgdfg'),
(24, 'uiu', 'erer'),
(25, 'test', 'test'),
(26, 'pp', 'pp'),
(27, 'zxdf', 'dff');

-- --------------------------------------------------------

--
-- Structure de la table `docteur`
--

CREATE TABLE `docteur` (
  `ID_D` int(11) NOT NULL,
  `nom_D` varchar(40) NOT NULL,
  `mdp_D` varchar(20) NOT NULL,
  `type` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `docteur`
--

INSERT INTO `docteur` (`ID_D`, `nom_D`, `mdp_D`, `type`) VALUES
(5, 'aymane', 'aymane', 'docteur'),
(6, '123', '123', 'docteur'),
(7, 'aym', 'aym', 'docteur'),
(8, 'qwe', 'qwe', 'secretaire'),
(9, 'a', 'a', 'secretaire'),
(10, '', '', 'secretaire');

-- --------------------------------------------------------

--
-- Structure de la table `mutuelle`
--

CREATE TABLE `mutuelle` (
  `ID_M` int(11) NOT NULL,
  `num_M` int(11) NOT NULL,
  `nom_M` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `mutuelle`
--

INSERT INTO `mutuelle` (`ID_M`, `num_M`, `nom_M`) VALUES
(1, 12, 'qw'),
(2, 23, 'dfgdfg'),
(3, 1221, 'asd'),
(4, 1212, 'cnops'),
(5, 190, 'daqw'),
(6, 98, 'qwe'),
(7, 1209, 'hahi'),
(8, 1234, 'aa'),
(9, 121, 'asas'),
(10, 234, 'ghj'),
(11, 9989, 'haaa'),
(12, 23, 'asc'),
(13, 988, 'hgh'),
(14, 12313, 'adasd'),
(15, 1919, 'qazxsw'),
(16, 333, 'xxx'),
(17, 123, 'afaf'),
(18, 98761234, 'test'),
(19, 323, 'adad'),
(20, 99, 'test'),
(21, 0, 'NULL'),
(22, 9999, 'test'),
(23, 19, 'test'),
(24, 19, 'pp'),
(25, 1123, 'dhsjs');

-- --------------------------------------------------------

--
-- Structure de la table `patient`
--

CREATE TABLE `patient` (
  `ID_P` int(11) NOT NULL,
  `nom_P` varchar(30) NOT NULL,
  `prenom_P` varchar(30) NOT NULL,
  `age_P` int(11) NOT NULL,
  `sex` varchar(30) NOT NULL,
  `ID_R` int(11) NOT NULL,
  `ID_CM` int(11) NOT NULL,
  `ID_M` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `patient`
--

INSERT INTO `patient` (`ID_P`, `nom_P`, `prenom_P`, `age_P`, `sex`, `ID_R`, `ID_CM`, `ID_M`) VALUES
(5, 'aymaa', 'ammaa', 19, 'Hommes', 6, 10, 6),
(7, 'ay', 'ay', 21, 'Hommes', 6, 12, 8),
(8, 'asd', 'asdd', 14, 'Hommes', 6, 13, 9),
(9, 'qpqq', 'dfgh', 456, 'Hommes', 6, 14, 10),
(10, 'asdasd', 'qwe', 155, 'Hommes', 6, 2, 2),
(11, 'bn', 'ggh', 87, 'Hommes', 6, 16, 13),
(12, 'sdf', 'sfsdfq2', 433, 'Hommes', 16, 17, 14),
(13, 'ayman', 'qwe', 19, 'Hommes', 17, 18, 15),
(14, 'xxx', 'xxx', 3, 'Femme', 18, 19, 16),
(15, 'asdkj', 'asdasd', 123, 'Hommes', 19, 20, 17),
(18, 'poop', 'pop', 12, 'Hommes', 21, 22, 19),
(19, 'pqidjd', 'ffwwe', 12, 'Hommes', 22, 23, 11),
(20, 'testvb', 'test', 19, 'Hommes', 23, 24, 11),
(21, 'elkhazenti', 'aym', 21, 'Hommes', 24, 25, 20),
(22, 'pp', 'pp', 19, 'Hommes', 23, 26, 21),
(23, 'teees', 'tees', 19, 'Hommes', 26, 27, 21);

-- --------------------------------------------------------

--
-- Structure de la table `rdv`
--

CREATE TABLE `rdv` (
  `ID_R` int(11) NOT NULL,
  `date_R` date NOT NULL,
  `ID_D` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `rdv`
--

INSERT INTO `rdv` (`ID_R`, `date_R`, `ID_D`) VALUES
(1, '2019-05-14', 1),
(2, '2019-04-11', 0),
(3, '2019-04-11', 0),
(4, '2019-05-06', 0),
(5, '2019-05-06', 0),
(6, '2000-12-12', 6),
(7, '1999-12-12', 0),
(8, '2019-05-06', 6),
(9, '2019-04-11', 6),
(10, '2019-04-11', 7),
(11, '2019-04-24', 6),
(12, '2019-05-24', 6),
(13, '2014-01-29', 6),
(14, '2013-11-16', 6),
(15, '2020-11-18', 6),
(16, '2020-07-21', 5),
(17, '2000-04-11', 6),
(18, '2034-10-19', 9),
(19, '2010-06-25', 6),
(20, '2019-05-11', 10),
(21, '2019-05-11', 10),
(22, '2019-05-30', 10),
(23, '2019-05-26', 6),
(24, '2019-05-17', 5),
(25, '2019-05-26', 10),
(26, '2019-05-28', 5);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `cahier_med`
--
ALTER TABLE `cahier_med`
  ADD PRIMARY KEY (`ID_CM`);

--
-- Index pour la table `docteur`
--
ALTER TABLE `docteur`
  ADD PRIMARY KEY (`ID_D`);

--
-- Index pour la table `mutuelle`
--
ALTER TABLE `mutuelle`
  ADD PRIMARY KEY (`ID_M`);

--
-- Index pour la table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`ID_P`),
  ADD KEY `ID_M` (`ID_M`),
  ADD KEY `ID_CM` (`ID_CM`),
  ADD KEY `ID_R` (`ID_R`);

--
-- Index pour la table `rdv`
--
ALTER TABLE `rdv`
  ADD PRIMARY KEY (`ID_R`),
  ADD KEY `ID_D` (`ID_D`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `cahier_med`
--
ALTER TABLE `cahier_med`
  MODIFY `ID_CM` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=28;

--
-- AUTO_INCREMENT pour la table `docteur`
--
ALTER TABLE `docteur`
  MODIFY `ID_D` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT pour la table `mutuelle`
--
ALTER TABLE `mutuelle`
  MODIFY `ID_M` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT pour la table `patient`
--
ALTER TABLE `patient`
  MODIFY `ID_P` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=24;

--
-- AUTO_INCREMENT pour la table `rdv`
--
ALTER TABLE `rdv`
  MODIFY `ID_R` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `patient`
--
ALTER TABLE `patient`
  ADD CONSTRAINT `patient_ibfk_1` FOREIGN KEY (`ID_M`) REFERENCES `mutuelle` (`ID_M`),
  ADD CONSTRAINT `patient_ibfk_2` FOREIGN KEY (`ID_CM`) REFERENCES `cahier_med` (`ID_CM`),
  ADD CONSTRAINT `patient_ibfk_3` FOREIGN KEY (`ID_R`) REFERENCES `rdv` (`ID_R`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
