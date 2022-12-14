/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Agozie
 */
@Entity
@Table(name = "__EFMigrationsHistory")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "EFMigrationsHistory.findAll", query = "SELECT e FROM EFMigrationsHistory e"),
    @NamedQuery(name = "EFMigrationsHistory.findByMigrationId", query = "SELECT e FROM EFMigrationsHistory e WHERE e.migrationId = :migrationId"),
    @NamedQuery(name = "EFMigrationsHistory.findByProductVersion", query = "SELECT e FROM EFMigrationsHistory e WHERE e.productVersion = :productVersion")})
public class EFMigrationsHistory implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @Basic(optional = false)
    @Column(name = "MigrationId")
    private String migrationId;
    @Basic(optional = false)
    @Column(name = "ProductVersion")
    private String productVersion;

    public EFMigrationsHistory() {
    }

    public EFMigrationsHistory(String migrationId) {
        this.migrationId = migrationId;
    }

    public EFMigrationsHistory(String migrationId, String productVersion) {
        this.migrationId = migrationId;
        this.productVersion = productVersion;
    }

    public String getMigrationId() {
        return migrationId;
    }

    public void setMigrationId(String migrationId) {
        this.migrationId = migrationId;
    }

    public String getProductVersion() {
        return productVersion;
    }

    public void setProductVersion(String productVersion) {
        this.productVersion = productVersion;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (migrationId != null ? migrationId.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof EFMigrationsHistory)) {
            return false;
        }
        EFMigrationsHistory other = (EFMigrationsHistory) object;
        if ((this.migrationId == null && other.migrationId != null) || (this.migrationId != null && !this.migrationId.equals(other.migrationId))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "model.EFMigrationsHistory[ migrationId=" + migrationId + " ]";
    }
    
}
