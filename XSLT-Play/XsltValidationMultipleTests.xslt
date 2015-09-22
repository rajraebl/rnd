<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
                xmlns:my="urn:sample" extension-element-prefixes="msxml">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>
  
  <msxsl:script language="JScript" implements-prefix="my">
    function today()
    {
      return new Date();
    }

    function add(x, y)
    {
      return  parseInt(x,10)+y;
    }
  </msxsl:script>
  
  <xsl:template match="risks">
    <xsl:for-each select="risk">
      <xsl:variable name="pola" >
        <xsl:value-of select="LicenseCancellation"/>
      </xsl:variable>
    <xsl:if test="(insuredDriverType='MyChild') or (insuredDriverType='MyParents')">
      Do Not Send Rule 2 Applied --- insured driver type = <xsl:value-of select="insuredDriverType"/>
      and id = <xsl:value-of select="@id"/> and date is = <xsl:value-of select="my:today()"/>
      and addition is <xsl:value-of select ="my:add($pola, 6)"/>
      <br></br>
    </xsl:if>

      <xsl:if test="(LicenseCancellation > 1) and (normalize-space(insuredDriverType)='UrParents')">
        Do Not Send Rule 4 Applied --- insured driver type = <xsl:value-of select="insuredDriverType"/>
        and id = <xsl:value-of select="@id"/> 
        <br></br>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>
