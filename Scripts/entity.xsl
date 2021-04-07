<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns="http://www.w3.org/1999/xhtml">
  <xsl:output method="text" indent="no" encoding="utf-8"/>
    
    <xsl:template match="/">
        <xsl:for-each select="/root">
            <xsl:for-each select="model">
                <xsl:apply-templates mode="gen-entity" select="."></xsl:apply-templates>
                <xsl:apply-templates mode="gen-controller" select="."></xsl:apply-templates>
                <xsl:apply-templates mode="gen-irepository" select="."></xsl:apply-templates>
                <xsl:apply-templates mode="gen-iservice" select="."></xsl:apply-templates>
                <xsl:apply-templates mode="gen-model" select="."></xsl:apply-templates>
                <xsl:apply-templates mode="gen-viewmodel" select="."></xsl:apply-templates>
                <xsl:apply-templates mode="gen-service" select="."></xsl:apply-templates>
                <xsl:apply-templates mode="gen-map" select="."></xsl:apply-templates>
                <xsl:apply-templates mode="gen-repository" select="."></xsl:apply-templates>
            </xsl:for-each>
		</xsl:for-each>
	</xsl:template>
    
    <xsl:variable name="LESSTHAN"><xsl:text><![CDATA[<]]></xsl:text></xsl:variable>
    <xsl:variable name="MORETHAN"><xsl:text><![CDATA[>]]></xsl:text></xsl:variable>

<!-- Entity -->

<xsl:template mode="gen-entity" match="model">[_BEGIN_FILE_: SICSinop.Domain\Entities\<xsl:value-of select="name"/>.cs]using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Entities
{
    public class <xsl:value-of select="name" disable-output-escaping="yes"/> : BaseEntity
    {
        <xsl:for-each select="properties/property">
            <xsl:variable name="vtype">
                <xsl:choose>
                    <xsl:when test="ptype"><xsl:value-of select="ptype"/></xsl:when>
                    <xsl:otherwise>String</xsl:otherwise>
                </xsl:choose>
            </xsl:variable>
            <xsl:variable name="vnullable">
                <xsl:choose>
                    <xsl:when test="pnullable = true">?</xsl:when>
                    <xsl:otherwise></xsl:otherwise>
                </xsl:choose>
            </xsl:variable><xsl:choose><xsl:when test="pskiponentity = 'false'">public <xsl:value-of select="$vtype"/><xsl:text> </xsl:text><xsl:value-of select="$vnullable"/><xsl:text></xsl:text><xsl:value-of select="pname"/> { get; set; }
        </xsl:when></xsl:choose>
        </xsl:for-each>
        <xsl:for-each select="relationships/relationship">
            <xsl:choose>
                <xsl:when test="rhas = 'many'">
        public ICollection<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="rname"/><xsl:value-of select="$MORETHAN"/><xsl:value-of select="rplural"/> { get; set; } = new List<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="rname"/><xsl:value-of select="$MORETHAN"/>();
                </xsl:when>
                <xsl:when test="rhas = 'one'">
        public <xsl:value-of select="rname"/><xsl:text> </xsl:text><xsl:value-of select="rname"/> { get; set; }
                </xsl:when>
            </xsl:choose>
        </xsl:for-each>
    }
}[_END_FILE_]</xsl:template>

<!-- Controller -->

<xsl:template mode="gen-controller" match="model">[_BEGIN_FILE_: SICSinop.API\Controllers\<xsl:value-of select="name"/>Controller.cs]using SICSinop.Domain.Interfaces.Services;
using SICSinop.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SICSinop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class <xsl:value-of select="name"/>Controller
    {
        private readonly I<xsl:value-of select="name"/>Service _<xsl:value-of select="id"/>Service;

        public <xsl:value-of select="name"/>Controller(I<xsl:value-of select="name"/>Service <xsl:value-of select="id"/>Service)
        {
            _<xsl:value-of select="id"/>Service = <xsl:value-of select="id"/>Service;
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="name"/>ViewModel<xsl:value-of select="$MORETHAN"/> GetAll()
        {
            return _<xsl:value-of select="id"/>Service.GetAll<xsl:value-of select="plural"/>();
        }

        [HttpGet]
        [Route("{id}")]
        public <xsl:value-of select="name"/>ViewModel Get(int id)
        {
            return _<xsl:value-of select="id"/>Service.Get<xsl:value-of select="name"/>ById(id);
        }

        [HttpPost]
        public <xsl:value-of select="name"/>Model Post([FromBody] <xsl:value-of select="name"/>Model model)
        {
            return _<xsl:value-of select="id"/>Service.Save<xsl:value-of select="name"/>(model);
        }

        [HttpPut]
        public <xsl:value-of select="name"/>Model Put([FromBody] <xsl:value-of select="name"/>Model model)
        {
            return _<xsl:value-of select="id"/>Service.Update<xsl:value-of select="name"/>(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _<xsl:value-of select="id"/>Service.Delete<xsl:value-of select="name"/>(id);
        }
    }
}[_END_FILE_]</xsl:template>

<!-- IRepository -->

<xsl:template mode="gen-irepository" match="model">[_BEGIN_FILE_: SICSinop.Domain\Interfaces\Repository\I<xsl:value-of select="name"/>Repository.cs]using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Interfaces.Repository
{
    public interface I<xsl:value-of select="name"/>Repository
    {
        List<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="name"/><xsl:value-of select="$MORETHAN"/> GetAll<xsl:value-of select="plural"/>();
        <xsl:value-of select="name"/> Get<xsl:value-of select="name"/>ById(int id);
        <xsl:value-of select="name"/> Create<xsl:value-of select="name"/>(<xsl:value-of select="name"/><xsl:text> </xsl:text><xsl:value-of select="id"/>);
        <xsl:value-of select="name"/> Update<xsl:value-of select="name"/>(<xsl:value-of select="name"/><xsl:text> </xsl:text><xsl:value-of select="id"/>);
        void Create<xsl:value-of select="name"/>List(List<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="name"/><xsl:value-of select="$MORETHAN"/> list);
        <xsl:value-of select="name"/> Delete<xsl:value-of select="name"/>(<xsl:value-of select="name"/><xsl:text> </xsl:text><xsl:value-of select="id"/>);
	}
}[_END_FILE_]</xsl:template>

<!-- IService -->

<xsl:template mode="gen-iservice" match="model">[_BEGIN_FILE_: SICSinop.Domain\Interfaces\Services\I<xsl:value-of select="name"/>Service.cs]using SICSinop.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Interfaces.Services
{
    public interface I<xsl:value-of select="name"/>Service
    {
        ICollection<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="name"/>ViewModel<xsl:value-of select="$MORETHAN"/> GetAll<xsl:value-of select="plural"/>();
        <xsl:value-of select="name"/>ViewModel Get<xsl:value-of select="name"/>ById(int id);
		<xsl:value-of select="name"/>Model Save<xsl:value-of select="name"/>(<xsl:value-of select="name"/>Model model);
        <xsl:value-of select="name"/>Model Update<xsl:value-of select="name"/>(<xsl:value-of select="name"/>Model model);
        bool Delete<xsl:value-of select="name"/>(int id);
    }
}[_END_FILE_]</xsl:template>

<!-- Model -->

<xsl:template mode="gen-model" match="model">[_BEGIN_FILE_: SICSinop.Domain\Model\<xsl:value-of select="name"/>Model.cs]using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class <xsl:value-of select="name"/>Model
    {
        <xsl:for-each select="properties/property">
            <xsl:variable name="vtype">
                <xsl:choose>
                    <xsl:when test="ptype"><xsl:value-of select="ptype"/></xsl:when>
                    <xsl:otherwise>String</xsl:otherwise>
                </xsl:choose>
            </xsl:variable>
            <xsl:variable name="vnullable">
                <xsl:choose>
                    <xsl:when test="pnullable=true">?</xsl:when>
                    <xsl:otherwise></xsl:otherwise>
                </xsl:choose>
            </xsl:variable>public <xsl:value-of select="$vtype"/><xsl:value-of select="$vnullable"/><xsl:text> </xsl:text><xsl:value-of select="pname"/> { get; set; }
        </xsl:for-each>
    }
}[_END_FILE_]</xsl:template>

<!-- ViewModel -->

<xsl:template mode="gen-viewmodel" match="model">[_BEGIN_FILE_: SICSinop.Domain\Model\<xsl:value-of select="name"/>ViewModel.cs]using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class <xsl:value-of select="name"/>ViewModel
    {
        <xsl:for-each select="properties/property">
            <xsl:variable name="vtype">
                <xsl:choose>
                    <xsl:when test="ptype"><xsl:value-of select="ptype"/></xsl:when>
                    <xsl:otherwise>String</xsl:otherwise>
                </xsl:choose>
            </xsl:variable>
            <xsl:variable name="vnullable">
                <xsl:choose>
                    <xsl:when test="pnullable=true">?</xsl:when>
                    <xsl:otherwise></xsl:otherwise>
                </xsl:choose>
            </xsl:variable>public <xsl:value-of select="$vtype"/><xsl:value-of select="$vnullable"/><xsl:text> </xsl:text><xsl:value-of select="pname"/> { get; set; }
        </xsl:for-each>
        public <xsl:value-of select="name"/>ViewModel FromModel(<xsl:value-of select="name"/><xsl:text> </xsl:text><xsl:value-of select="id"/>)
        {
            return new <xsl:value-of select="name"/>ViewModel()
            {
                <xsl:variable name="modelid"><xsl:value-of select="id"/></xsl:variable><xsl:for-each select="properties/property">
                <xsl:value-of select="pname"/> = <xsl:value-of select="$modelid"/>.<xsl:value-of select="pname"/>,
                </xsl:for-each>
            };
        }
    }
}[_END_FILE_]</xsl:template>

<!-- Service -->

<xsl:template mode="gen-service" match="model">[_BEGIN_FILE_: SICSinop.Domain\Services\<xsl:value-of select="name"/>Service.cs]using SICSinop.Domain.Entities;
using SICSinop.Domain.Interfaces.Repository;
using SICSinop.Domain.Interfaces.Services;
using SICSinop.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICSinop.Domain.Services
{
    public class <xsl:value-of select="name"/>Service : I<xsl:value-of select="name"/>Service
    {
        private readonly I<xsl:value-of select="name"/>Repository _<xsl:value-of select="id"/>Repository;

        public <xsl:value-of select="name"/>Service(I<xsl:value-of select="name"/>Repository <xsl:value-of select="id"/>Repository)
        {
            _<xsl:value-of select="id"/>Repository = <xsl:value-of select="id"/>Repository;
        }

        public ICollection<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="name"/>ViewModel<xsl:value-of select="$MORETHAN"/> GetAll<xsl:value-of select="plural"/>()
        {
            return _<xsl:value-of select="id"/>Repository.GetAll<xsl:value-of select="plural"/>()
                .Select(<xsl:value-of select="id"/> => new <xsl:value-of select="name"/>ViewModel()
                {
                    <xsl:variable name="modelid"><xsl:value-of select="id"/></xsl:variable><xsl:for-each select="properties/property">
                    <xsl:value-of select="pname"/> = <xsl:value-of select="$modelid"/>.<xsl:value-of select="pname"/>,
                    </xsl:for-each>
                })
                .ToList();
        }

        public <xsl:value-of select="name"/>ViewModel Get<xsl:value-of select="name"/>ById(int id)
        {
            var <xsl:value-of select="id"/> = _<xsl:value-of select="id"/>Repository.Get<xsl:value-of select="name"/>ById(id);
            return (<xsl:value-of select="id"/> != null ? new <xsl:value-of select="name"/>ViewModel()
            {
                <xsl:for-each select="properties/property">
                <xsl:value-of select="pname"/> = <xsl:value-of select="$modelid"/>.<xsl:value-of select="pname"/>,
                </xsl:for-each>
            } : null);
        }
		
		public <xsl:value-of select="name"/>Model Save<xsl:value-of select="name"/>(<xsl:value-of select="name"/>Model model)
        {
            var <xsl:value-of select="id"/> = new <xsl:value-of select="name"/>()
            {
                <xsl:for-each select="properties/property">
                <xsl:value-of select="pname"/> = model.<xsl:value-of select="pname"/>,
                </xsl:for-each>
            };
			
            <xsl:value-of select="id"/> = _<xsl:value-of select="id"/>Repository.Create<xsl:value-of select="name"/>(<xsl:value-of select="id"/>);
			
            return new <xsl:value-of select="name"/>Model()
            {
                <xsl:for-each select="properties/property">
                <xsl:value-of select="pname"/> = <xsl:value-of select="$modelid"/>.<xsl:value-of select="pname"/>,
                </xsl:for-each>
            };
        }

        public <xsl:value-of select="name"/>Model Update<xsl:value-of select="name"/>(<xsl:value-of select="name"/>Model model)
        {
            var <xsl:value-of select="id"/> = new <xsl:value-of select="name"/>()
            {
                <xsl:for-each select="properties/property">
                <xsl:value-of select="pname"/> = model.<xsl:value-of select="pname"/>,
                </xsl:for-each>
            };
			
            <xsl:value-of select="id"/> = _<xsl:value-of select="id"/>Repository.Update<xsl:value-of select="name"/>(<xsl:value-of select="id"/>);
			
            return new <xsl:value-of select="name"/>Model()
            {
                Id = <xsl:value-of select="$modelid"/>.Id,
				<xsl:for-each select="properties/property"><xsl:choose><xsl:when test="pname != 'Id'"><xsl:value-of select="pname"/> = model.<xsl:value-of select="pname"/>,
				</xsl:when></xsl:choose></xsl:for-each>
            };
        }

        public bool Delete<xsl:value-of select="name"/>(int id)
        {
            try
            {
                var <xsl:value-of select="id"/> = _<xsl:value-of select="id"/>Repository.Get<xsl:value-of select="name"/>ById(id);
                if (<xsl:value-of select="id"/> == null)
                {
                    throw new Exception("Not found!");
                }

                _<xsl:value-of select="id"/>Repository.Delete<xsl:value-of select="name"/>(<xsl:value-of select="id"/>);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}[_END_FILE_]</xsl:template>

<!-- Map -->

<xsl:template mode="gen-map" match="model">[_BEGIN_FILE_: SICSinop.Infrastructure\Data\Mapping\<xsl:value-of select="name"/>Map.cs]using SICSinop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Data.Mapping
{
    public class <xsl:value-of select="name"/>Map : IEntityTypeConfiguration<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="name"/><xsl:value-of select="$MORETHAN"/>
    {
        public void Configure(EntityTypeBuilder<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="name"/><xsl:value-of select="$MORETHAN"/> builder)
        {
            builder
                .ToTable("<xsl:value-of select="name"/>");<xsl:variable name="modelname"><xsl:value-of select="name"/></xsl:variable><xsl:variable name="modelplural"><xsl:value-of select="plural"/></xsl:variable><xsl:for-each select="properties/property">
                <xsl:choose>
                    <xsl:when test="pname='Id'">
            builder
                .HasKey(x => x.<xsl:value-of select="pname"/>);</xsl:when><xsl:otherwise>
            builder
                .Property(x => x.<xsl:value-of select="pname"/>);</xsl:otherwise></xsl:choose></xsl:for-each>

            <xsl:for-each select="relationships/relationship">
                <xsl:choose>
                    <xsl:when test="rhas='many'">
            builder
                .HasMany(x => x.<xsl:value-of select="rplural"/>)
                .WithOne(x => x.<xsl:value-of select="$modelname"/>);
                    </xsl:when>
                    <xsl:when test="rhas='one'">
            builder
                .HasOne(x => x.<xsl:value-of select="rname"/>)
                .WithMany(x => x.<xsl:value-of select="$modelplural"/>)
	            <xsl:choose><xsl:when test="usefield">.HasForeignKey(x => x.<xsl:value-of select="usefield"/>);</xsl:when><xsl:otherwise>;</xsl:otherwise></xsl:choose></xsl:when></xsl:choose></xsl:for-each>
        }
    }
}
[_END_FILE_]</xsl:template>
	
<!-- Repository -->

<xsl:template mode="gen-repository" match="model">[_BEGIN_FILE_: SICSinop.Infrastructure\Data\Repository\<xsl:value-of select="name"/>Repository.cs]using SICSinop.Domain.Entities;
using SICSinop.Domain.Interfaces.Repository;
using SICSinop.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICSinop.Domain.Data.Repository
{
    public class <xsl:value-of select="name"/>Repository : Repository<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="name"/><xsl:value-of select="$MORETHAN"/>, I<xsl:value-of select="name"/>Repository
    {
        public <xsl:value-of select="name"/>Repository(MainDbContext context) : base(context) { }

        public List<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="name"/><xsl:value-of select="$MORETHAN"/> GetAll<xsl:value-of select="plural"/>()
        {
            return GetAll().ToList();
        }

        public <xsl:value-of select="name"/> Get<xsl:value-of select="name"/>ById(int id)
        {
            return FindById(id);
        }

        public <xsl:value-of select="name"/> Create<xsl:value-of select="name"/>(<xsl:value-of select="name"/><xsl:text> </xsl:text><xsl:value-of select="id"/>)
        {
            Create(<xsl:value-of select="id"/>);
            SaveChanges();
            return <xsl:value-of select="id"/>;
        }

        public <xsl:value-of select="name"/> Update<xsl:value-of select="name"/>(<xsl:value-of select="name"/><xsl:text> </xsl:text><xsl:value-of select="id"/>)
        {
            Update(<xsl:value-of select="id"/>);
            SaveChanges();
            return <xsl:value-of select="id"/>;
        }

        public void Create<xsl:value-of select="name"/>List(List<xsl:value-of select="$LESSTHAN"/><xsl:value-of select="name"/><xsl:value-of select="$MORETHAN"/> list)
        {
            Create(list);
            SaveChanges();
        }

        public <xsl:value-of select="name"/> Delete<xsl:value-of select="name"/>(<xsl:value-of select="name"/><xsl:text> </xsl:text><xsl:value-of select="id"/>)
        {
            Remove(<xsl:value-of select="id"/>);
            SaveChanges();
            return <xsl:value-of select="id"/>;
        }
    }
}

[_END_FILE_]</xsl:template>

</xsl:stylesheet>
